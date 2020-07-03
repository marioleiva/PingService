namespace appservice.Presentacion.Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvIps = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.btnDescarga = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIps)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConsultar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConsultar.Location = new System.Drawing.Point(13, 405);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(224, 23);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "PRUEBA DE CONECTIVIDAD";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // dgvIps
            // 
            this.dgvIps.AllowUserToAddRows = false;
            this.dgvIps.AllowUserToDeleteRows = false;
            this.dgvIps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.Ip,
            this.Usuario,
            this.Servicio});
            this.dgvIps.Location = new System.Drawing.Point(13, 26);
            this.dgvIps.Name = "dgvIps";
            this.dgvIps.Size = new System.Drawing.Size(380, 364);
            this.dgvIps.TabIndex = 2;
            this.dgvIps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIps_CellContentClick);
            // 
            // chk
            // 
            this.chk.HeaderText = "chk";
            this.chk.Name = "chk";
            this.chk.Width = 35;
            // 
            // Ip
            // 
            this.Ip.HeaderText = "Ip";
            this.Ip.Name = "Ip";
            this.Ip.Width = 90;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Width = 120;
            // 
            // Servicio
            // 
            this.Servicio.HeaderText = "Servicio";
            this.Servicio.Name = "Servicio";
            this.Servicio.Width = 85;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(291, 405);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(399, 26);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(399, 364);
            this.txtRespuesta.TabIndex = 5;
            // 
            // btnDescarga
            // 
            this.btnDescarga.Location = new System.Drawing.Point(465, 405);
            this.btnDescarga.Name = "btnDescarga";
            this.btnDescarga.Size = new System.Drawing.Size(107, 23);
            this.btnDescarga.TabIndex = 6;
            this.btnDescarga.Text = "DESCARGA TXT";
            this.btnDescarga.UseVisualStyleBackColor = true;
            this.btnDescarga.Click += new System.EventHandler(this.BtnDescarga_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvIps);
            this.panel1.Controls.Add(this.btnDescarga);
            this.panel1.Controls.Add(this.txtRespuesta);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Location = new System.Drawing.Point(11, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 443);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(842, 480);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "::: SISTEMAS DYNAMICALL :::";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIps)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvIps;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Button btnDescarga;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Servicio;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

