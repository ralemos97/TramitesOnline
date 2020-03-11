namespace WinServicioTramites
{
    partial class HorasExtrasService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elLogger = new System.Diagnostics.EventLog();
            this.fswHorasExtras = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.elLogger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswHorasExtras)).BeginInit();
            // 
            // fswHorasExtras
            // 
            this.fswHorasExtras.EnableRaisingEvents = true;
            this.fswHorasExtras.Created += new System.IO.FileSystemEventHandler(this.fswHorasExtras_Created);
            this.fswHorasExtras.Deleted += new System.IO.FileSystemEventHandler(this.fswHorasExtras_Deleted);
            // 
            // HorasExtrasService
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.elLogger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswHorasExtras)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog elLogger;
        private System.IO.FileSystemWatcher fswHorasExtras;
    }
}
