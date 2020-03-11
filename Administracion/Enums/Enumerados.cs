namespace Administracion.Enums
{
    internal class Enumerados
    {
        public enum Estados
        {
            Alta,
            Ejecutada,
            Anulada
        }

        public enum FiltroSolicitudes
        {
            Default,
            ResumenTipoTramite,
            ResumenMensual,
            ResumenUsoDocumentacion,
            FiltroFecha
        }

        public enum Meses
        {
            Enero = 1, 
            Febrero,
            Marzo,
            Abril,
            Mayo,
            Junio,
            Julio,
            Agosto,
            Septiembre,
            Octubre,
            Noviembre,
            Diciembre
        }
    }
}
