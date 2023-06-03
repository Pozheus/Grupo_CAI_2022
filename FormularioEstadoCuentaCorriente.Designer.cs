namespace Grupo_C_CAI
{
    partial class FormularioEstadoCuentaCorriente
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
            this.label1 = new System.Windows.Forms.Label();
            this.facturasListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.solicitudesPendientesListBox = new System.Windows.Forms.ListBox();
            this.saldoLbl = new System.Windows.Forms.Label();
            this.volverBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.detalleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturación";
            // 
            // facturasListBox
            // 
            this.facturasListBox.DisplayMember = "NombreConDatos";
            this.facturasListBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.facturasListBox.FormattingEnabled = true;
            this.facturasListBox.ItemHeight = 15;
            this.facturasListBox.Location = new System.Drawing.Point(12, 68);
            this.facturasListBox.Name = "facturasListBox";
            this.facturasListBox.Size = new System.Drawing.Size(660, 94);
            this.facturasListBox.TabIndex = 1;
            this.facturasListBox.ValueMember = "NombreConDatos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.Location = new System.Drawing.Point(12, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Servicios cumplidos pendientes de facturación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.Location = new System.Drawing.Point(208, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Saldo total";
            // 
            // solicitudesPendientesListBox
            // 
            this.solicitudesPendientesListBox.DisplayMember = "NombreConDatos";
            this.solicitudesPendientesListBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.solicitudesPendientesListBox.FormattingEnabled = true;
            this.solicitudesPendientesListBox.ItemHeight = 15;
            this.solicitudesPendientesListBox.Location = new System.Drawing.Point(12, 260);
            this.solicitudesPendientesListBox.Name = "solicitudesPendientesListBox";
            this.solicitudesPendientesListBox.Size = new System.Drawing.Size(660, 64);
            this.solicitudesPendientesListBox.TabIndex = 4;
            this.solicitudesPendientesListBox.ValueMember = "NombreConDatos";
            // 
            // saldoLbl
            // 
            this.saldoLbl.AutoSize = true;
            this.saldoLbl.Font = new System.Drawing.Font("Calibri", 10F);
            this.saldoLbl.Location = new System.Drawing.Point(305, 353);
            this.saldoLbl.Name = "saldoLbl";
            this.saldoLbl.Size = new System.Drawing.Size(22, 17);
            this.saldoLbl.TabIndex = 5;
            this.saldoLbl.Text = "$0";
            // 
            // volverBtn
            // 
            this.volverBtn.Font = new System.Drawing.Font("Calibri", 10F);
            this.volverBtn.Location = new System.Drawing.Point(425, 349);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(75, 23);
            this.volverBtn.TabIndex = 6;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F);
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Facturas";
            // 
            // detalleBtn
            // 
            this.detalleBtn.Location = new System.Drawing.Point(310, 168);
            this.detalleBtn.Name = "detalleBtn";
            this.detalleBtn.Size = new System.Drawing.Size(75, 23);
            this.detalleBtn.TabIndex = 8;
            this.detalleBtn.Text = "Ver detalle";
            this.detalleBtn.UseVisualStyleBackColor = true;
            this.detalleBtn.Click += new System.EventHandler(this.detalleBtn_Click);
            // 
            // FormularioEstadoCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 388);
            this.Controls.Add(this.detalleBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.saldoLbl);
            this.Controls.Add(this.solicitudesPendientesListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.facturasListBox);
            this.Controls.Add(this.label1);
            this.Name = "FormularioEstadoCuentaCorriente";
            this.Text = "FormularioEstadoCuentaCorriente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox facturasListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox solicitudesPendientesListBox;
        private System.Windows.Forms.Label saldoLbl;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button detalleBtn;
    }
}