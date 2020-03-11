namespace Administracion
{
    partial class ListadoSolicitudes
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoSolicitudes));
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAnual = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grpResumenes = new System.Windows.Forms.GroupBox();
            this.btnResMes = new System.Windows.Forms.Button();
            this.btnResTipoTramite = new System.Windows.Forms.Button();
            this.btnResDocumentacion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltroFecha = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.grpResumenes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToResizeRows = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(11, 208);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.RowHeadersVisible = false;
            this.dgvListado.RowTemplate.Height = 28;
            this.dgvListado.Size = new System.Drawing.Size(749, 271);
            this.dgvListado.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 17);
            this.lblStatus.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(556, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad de registros:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(730, 496);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 13);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "0";
            // 
            // btnAnual
            // 
            this.btnAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnual.Image = global::Administracion.Properties.Resources.anual;
            this.btnAnual.Location = new System.Drawing.Point(134, 21);
            this.btnAnual.Name = "btnAnual";
            this.btnAnual.Size = new System.Drawing.Size(105, 72);
            this.btnAnual.TabIndex = 10;
            this.btnAnual.Text = "Anual";
            this.btnAnual.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnual.UseVisualStyleBackColor = true;
            this.btnAnual.Click += new System.EventHandler(this.btnAnual_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleccioné el tipo de carga que desea realizar en la grilla:";
            // 
            // grpResumenes
            // 
            this.grpResumenes.Controls.Add(this.btnResMes);
            this.grpResumenes.Controls.Add(this.btnResTipoTramite);
            this.grpResumenes.Controls.Add(this.btnResDocumentacion);
            this.grpResumenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResumenes.Location = new System.Drawing.Point(15, 39);
            this.grpResumenes.Name = "grpResumenes";
            this.grpResumenes.Size = new System.Drawing.Size(432, 111);
            this.grpResumenes.TabIndex = 12;
            this.grpResumenes.TabStop = false;
            this.grpResumenes.Text = "Resumir por";
            // 
            // btnResMes
            // 
            this.btnResMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResMes.Image = global::Administracion.Properties.Resources.calendar2;
            this.btnResMes.Location = new System.Drawing.Point(300, 21);
            this.btnResMes.Name = "btnResMes";
            this.btnResMes.Size = new System.Drawing.Size(105, 72);
            this.btnResMes.TabIndex = 7;
            this.btnResMes.Text = "Mes";
            this.btnResMes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResMes.UseVisualStyleBackColor = true;
            this.btnResMes.Click += new System.EventHandler(this.btnResMes_Click);
            // 
            // btnResTipoTramite
            // 
            this.btnResTipoTramite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResTipoTramite.Image = global::Administracion.Properties.Resources.tipoTramite;
            this.btnResTipoTramite.Location = new System.Drawing.Point(18, 20);
            this.btnResTipoTramite.Name = "btnResTipoTramite";
            this.btnResTipoTramite.Size = new System.Drawing.Size(105, 73);
            this.btnResTipoTramite.TabIndex = 6;
            this.btnResTipoTramite.Text = "Tipo de tramite";
            this.btnResTipoTramite.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResTipoTramite.UseVisualStyleBackColor = true;
            this.btnResTipoTramite.Click += new System.EventHandler(this.btnResTipoTramite_Click);
            // 
            // btnResDocumentacion
            // 
            this.btnResDocumentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResDocumentacion.Image = global::Administracion.Properties.Resources.documentacion;
            this.btnResDocumentacion.Location = new System.Drawing.Point(158, 21);
            this.btnResDocumentacion.Name = "btnResDocumentacion";
            this.btnResDocumentacion.Size = new System.Drawing.Size(105, 72);
            this.btnResDocumentacion.TabIndex = 8;
            this.btnResDocumentacion.Text = "Documentación";
            this.btnResDocumentacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResDocumentacion.UseVisualStyleBackColor = true;
            this.btnResDocumentacion.Click += new System.EventHandler(this.btnResDocumentacion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFiltroFecha);
            this.groupBox1.Controls.Add(this.btnAnual);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(471, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 111);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Otros";
            // 
            // btnFiltroFecha
            // 
            this.btnFiltroFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroFecha.Image = global::Administracion.Properties.Resources.calendar;
            this.btnFiltroFecha.Location = new System.Drawing.Point(16, 21);
            this.btnFiltroFecha.Name = "btnFiltroFecha";
            this.btnFiltroFecha.Size = new System.Drawing.Size(105, 72);
            this.btnFiltroFecha.TabIndex = 9;
            this.btnFiltroFecha.Text = "Filtro fecha";
            this.btnFiltroFecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltroFecha.UseVisualStyleBackColor = true;
            this.btnFiltroFecha.Click += new System.EventHandler(this.btnFiltroFecha_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Filtro por fecha";
            // 
            // dtpFiltroFecha
            // 
            this.dtpFiltroFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpFiltroFecha.Enabled = false;
            this.dtpFiltroFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFecha.Location = new System.Drawing.Point(104, 172);
            this.dtpFiltroFecha.Name = "dtpFiltroFecha";
            this.dtpFiltroFecha.Size = new System.Drawing.Size(107, 20);
            this.dtpFiltroFecha.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(233, 170);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ListadoSolicitudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 556);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFiltroFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpResumenes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListadoSolicitudes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Solicitudes";
            this.Load += new System.EventHandler(this.ListadoSolicitudes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpResumenes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnResTipoTramite;
        private System.Windows.Forms.Button btnResDocumentacion;
        private System.Windows.Forms.Button btnResMes;
        private System.Windows.Forms.Button btnFiltroFecha;
        private System.Windows.Forms.Button btnAnual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpResumenes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFiltroFecha;
        private System.Windows.Forms.Button btnBuscar;
    }
}