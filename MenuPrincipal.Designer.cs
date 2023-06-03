namespace Grupo_C_CAI
{
    partial class MenuPrincipal
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
            this.generarSolicitudBtn = new System.Windows.Forms.Button();
            this.estadoSolicitudServiciobtn = new System.Windows.Forms.Button();
            this.estadoCuentaCorrienteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu principal";
            // 
            // generarSolicitudBtn
            // 
            this.generarSolicitudBtn.Font = new System.Drawing.Font("Calibri", 11F);
            this.generarSolicitudBtn.Location = new System.Drawing.Point(75, 125);
            this.generarSolicitudBtn.Name = "generarSolicitudBtn";
            this.generarSolicitudBtn.Size = new System.Drawing.Size(240, 57);
            this.generarSolicitudBtn.TabIndex = 1;
            this.generarSolicitudBtn.Text = "Generar solicitud de servicio";
            this.generarSolicitudBtn.UseVisualStyleBackColor = true;
            this.generarSolicitudBtn.Click += new System.EventHandler(this.generarSolicitudBtn_Click);
            // 
            // estadoSolicitudServiciobtn
            // 
            this.estadoSolicitudServiciobtn.Font = new System.Drawing.Font("Calibri", 11F);
            this.estadoSolicitudServiciobtn.Location = new System.Drawing.Point(75, 192);
            this.estadoSolicitudServiciobtn.Name = "estadoSolicitudServiciobtn";
            this.estadoSolicitudServiciobtn.Size = new System.Drawing.Size(240, 60);
            this.estadoSolicitudServiciobtn.TabIndex = 4;
            this.estadoSolicitudServiciobtn.Text = "Consultar estado de solicitud de servicio";
            this.estadoSolicitudServiciobtn.UseVisualStyleBackColor = true;
            this.estadoSolicitudServiciobtn.Click += new System.EventHandler(this.estadoSolicitudServiciobtn_Click);
            // 
            // estadoCuentaCorrienteBtn
            // 
            this.estadoCuentaCorrienteBtn.Font = new System.Drawing.Font("Calibri", 11F);
            this.estadoCuentaCorrienteBtn.Location = new System.Drawing.Point(75, 262);
            this.estadoCuentaCorrienteBtn.Name = "estadoCuentaCorrienteBtn";
            this.estadoCuentaCorrienteBtn.Size = new System.Drawing.Size(240, 60);
            this.estadoCuentaCorrienteBtn.TabIndex = 5;
            this.estadoCuentaCorrienteBtn.Text = "Consultar estado de cuenta corriente";
            this.estadoCuentaCorrienteBtn.UseVisualStyleBackColor = true;
            this.estadoCuentaCorrienteBtn.Click += new System.EventHandler(this.estadoCuentaCorrienteBtn_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.estadoCuentaCorrienteBtn);
            this.Controls.Add(this.estadoSolicitudServiciobtn);
            this.Controls.Add(this.generarSolicitudBtn);
            this.Controls.Add(this.label1);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generarSolicitudBtn;
        private System.Windows.Forms.Button estadoSolicitudServiciobtn;
        private System.Windows.Forms.Button estadoCuentaCorrienteBtn;
    }
}