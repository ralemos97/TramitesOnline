using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Timers;
using System.Xml.Linq;
using WinServicioTramites.WSTramitesOnline;

namespace WinServicioTramites
{
    public partial class HorasExtrasService : ServiceBase
    {

        Empleado empleadoActual = null;
        Timer timerHE = null;
        string ciXml = null, horaSalidaXml = null;

        public HorasExtrasService()
        {
            InitializeComponent();

            if (!EventLog.SourceExists("TramitesOnline"))
            {
                EventLog.CreateEventSource("TramitesOnline", "TramitesOnlineLogs");
            }

            elLogger.Source = "TramitesOnline";
            elLogger.Log = "TramitesOnlineLogs";

            try
            {
                timerHE = new Timer();
                timerHE.Enabled = true;
                timerHE.Interval = 1000 * 60;
                timerHE.Elapsed += new ElapsedEventHandler(timerHE_Tick);

                Assembly assembly = Assembly.GetExecutingAssembly();
                string fileNameApplication = Path.GetFileName(assembly.Location);
                string path = Path.Combine(assembly.Location.Replace(fileNameApplication, string.Empty), "Info");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fswHorasExtras.Path = path;
            }
            catch (System.Exception ex)
            {
                elLogger.WriteEntry(ex.Message + " | HoraExtraService Constructor", EventLogEntryType.Error);
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                elLogger.WriteEntry("ServiceTramitesOnline Iniciado", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                elLogger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                timerHE.Stop();
                empleadoActual = null;

                elLogger.WriteEntry("ServiceTramitesOnline Detenido", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                elLogger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        private void fswHorasExtras_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                XElement xmlDocument = XElement.Load(e.FullPath);
                ciXml = xmlDocument.Element("UserDoc").Value.ToString();
                horaSalidaXml = xmlDocument.Element("HoraSalida").Value.ToString();

                empleadoActual = new ServicioTramitesOnlineClient().BuscarEmpleado(ciXml);

                if (empleadoActual == null)
                {
                    throw new Exception("No se encontro empleado con el documento " + ciXml);
                }

                timerHE.Start();
                elLogger.WriteEntry("Empleado logueado: " + empleadoActual.Documento, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                elLogger.WriteEntry(ex.Message + " | File:" + e.Name, EventLogEntryType.Error);
            }
        }

        private void timerHE_Tick(object sender, EventArgs e)
        {
            try
            {
                if (empleadoActual == null)
                    return;

                string[] salidaXML = horaSalidaXml.Split(':');
                DateTime salida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(salidaXML[0]), Convert.ToInt32(salidaXML[1]), 0);
                HoraExtra extra = new HoraExtra();
                extra.Fecha = DateTime.Now;

                if (DateTime.Now > salida)
                {
                    extra.Minutos = (int)DateTime.Now.Subtract(salida).TotalMinutes;
                }

                if(extra.Minutos > 0)
                {
                    empleadoActual.HorasExtrasGeneradas = new List<HoraExtra>() { extra }.ToArray();
                }

                new ServicioTramitesOnlineClient().AgregarHoraExtra(empleadoActual);
            }
            catch (Exception ex)
            {
                elLogger.WriteEntry(ex.Message + " | Error generar tiempo extra [TimerHE_Tick].", EventLogEntryType.Error);
            }
        }

        private void fswHorasExtras_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                timerHE.Stop();
                elLogger.WriteEntry("Empleado deslogueado: " + empleadoActual.Documento, EventLogEntryType.Information);
                empleadoActual = null;
            }
            catch (Exception ex)
            {
                elLogger.WriteEntry(ex.Message + " | File:" + e.Name, EventLogEntryType.Error);
            }
        }
    }
}
