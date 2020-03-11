namespace Administracion
{
    partial class CambioEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioEstado));
            this.dgvCambioEstado = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTramite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anular = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Ejecutada = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFindText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambioEstado)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCambioEstado
            // 
            this.dgvCambioEstado.AllowUserToAddRows = false;
            this.dgvCambioEstado.AllowUserToDeleteRows = false;
            this.dgvCambioEstado.AllowUserToResizeColumns = false;
            this.dgvCambioEstado.AllowUserToResizeRows = false;
            this.dgvCambioEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambioEstado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.TipoTramite,
            this.DocumentoCliente,
            this.Documento,
            this.Anular,
            this.Ejecutada});
            this.dgvCambioEstado.Location = new System.Drawing.Point(11, 53);
            this.dgvCambioEstado.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCambioEstado.Name = "dgvCambioEstado";
            this.dgvCambioEstado.RowHeadersVisible = false;
            this.dgvCambioEstado.RowTemplate.Height = 28;
            this.dgvCambioEstado.Size = new System.Drawing.Size(715, 300);
            this.dgvCambioEstado.TabIndex = 0;
            this.dgvCambioEstado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCambioEstado_CellClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Id";
            this.Codigo.HeaderText = "ID";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TipoTramite
            // 
            this.TipoTramite.DataPropertyName = "Tipo";
            this.TipoTramite.HeaderText = "Tipo de tramite";
            this.TipoTramite.Name = "TipoTramite";
            this.TipoTramite.ReadOnly = true;
            this.TipoTramite.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TipoTramite.Width = 200;
            // 
            // DocumentoCliente
            // 
            this.DocumentoCliente.DataPropertyName = "Nombre";
            this.DocumentoCliente.HeaderText = "Nombre Emisor";
            this.DocumentoCliente.Name = "DocumentoCliente";
            this.DocumentoCliente.ReadOnly = true;
            this.DocumentoCliente.Width = 150;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Anular
            // 
            this.Anular.HeaderText = "";
            this.Anular.Name = "Anular";
            this.Anular.ReadOnly = true;
            this.Anular.Text = "Anular";
            this.Anular.ToolTipText = "Anular";
            this.Anular.UseColumnTextForButtonValue = true;
            this.Anular.Width = 80;
            // 
            // Ejecutada
            // 
            this.Ejecutada.HeaderText = "";
            this.Ejecutada.Name = "Ejecutada";
            this.Ejecutada.ReadOnly = true;
            this.Ejecutada.Text = "Ejecutar";
            this.Ejecutada.ToolTipText = "Ejecutar";
            this.Ejecutada.UseColumnTextForButtonValue = true;
            this.Ejecutada.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
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
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar";
            // 
            // txtFindText
            // 
            this.txtFindText.Location = new System.Drawing.Point(67, 16);
            this.txtFindText.Name = "txtFindText";
            this.txtFindText.Size = new System.Drawing.Size(246, 20);
            this.txtFindText.TabIndex = 5;
            this.txtFindText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindText_KeyUp);
            // 
            // CambioEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 387);
            this.Controls.Add(this.txtFindText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvCambioEstado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambioEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambio de estado";
            this.Load += new System.EventHandler(this.CambioEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambioEstado)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCambioEstado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFindText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTramite;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewButtonColumn Anular;
        private System.Windows.Forms.DataGridViewButtonColumn Ejecutada;
    }
}