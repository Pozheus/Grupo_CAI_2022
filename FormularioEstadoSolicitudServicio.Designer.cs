namespace Grupo_C_CAI
{
    partial class FormularioEstadoSolicitudServicio
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
            this.solicitudesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.estadoLbl = new System.Windows.Forms.Label();
            this.volverBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // solicitudesListBox
            // 
            this.solicitudesListBox.DisplayMember = "NombreConDatos";
            this.solicitudesListBox.Font = new System.Drawing.Font("Calibri", 10F);
            this.solicitudesListBox.FormattingEnabled = true;
            this.solicitudesListBox.ItemHeight = 15;
            this.solicitudesListBox.Location = new System.Drawing.Point(16, 79);
            this.solicitudesListBox.Name = "solicitudesListBox";
            this.solicitudesListBox.Size = new System.Drawing.Size(655, 79);
            this.solicitudesListBox.TabIndex = 0;
            this.solicitudesListBox.ValueMember = "NombreConDatos";
            this.solicitudesListBox.SelectedIndexChanged += new System.EventHandler(this.solicitudesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado de solicitud de servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione la solicitud a consultar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.Location = new System.Drawing.Point(270, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estado";
            // 
            // estadoLbl
            // 
            this.estadoLbl.AutoSize = true;
            this.estadoLbl.Font = new System.Drawing.Font("Calibri", 10F);
            this.estadoLbl.Location = new System.Drawing.Point(262, 199);
            this.estadoLbl.Name = "estadoLbl";
            this.estadoLbl.Size = new System.Drawing.Size(69, 17);
            this.estadoLbl.TabIndex = 4;
            this.estadoLbl.Text = "En tránsito";
            // 
            // volverBtn
            // 
            this.volverBtn.Font = new System.Drawing.Font("Calibri", 10F);
            this.volverBtn.Location = new System.Drawing.Point(420, 182);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(75, 23);
            this.volverBtn.TabIndex = 7;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // FormularioEstadoSolicitudServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 233);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.estadoLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solicitudesListBox);
            this.Name = "FormularioEstadoSolicitudServicio";
            this.Text = "FormularioEstadoSolicitudServicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox solicitudesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label estadoLbl;
        private System.Windows.Forms.Button volverBtn;
    }
}