
namespace Grupo_C_CAI
{
    partial class MenuInicio
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
            this.cuitTbox = new System.Windows.Forms.TextBox();
            this.passwordTbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cuitErrorLbl = new System.Windows.Forms.Label();
            this.passwordErrorLbl = new System.Windows.Forms.Label();
            this.Bienvenidos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(123, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUIT";
            // 
            // cuitTbox
            // 
            this.cuitTbox.Font = new System.Drawing.Font("Calibri", 10F);
            this.cuitTbox.Location = new System.Drawing.Point(126, 141);
            this.cuitTbox.MaxLength = 11;
            this.cuitTbox.Name = "cuitTbox";
            this.cuitTbox.Size = new System.Drawing.Size(160, 24);
            this.cuitTbox.TabIndex = 1;
            // 
            // passwordTbox
            // 
            this.passwordTbox.Font = new System.Drawing.Font("Calibri", 10F);
            this.passwordTbox.Location = new System.Drawing.Point(126, 203);
            this.passwordTbox.Name = "passwordTbox";
            this.passwordTbox.PasswordChar = '*';
            this.passwordTbox.Size = new System.Drawing.Size(160, 24);
            this.passwordTbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.Location = new System.Drawing.Point(123, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.submitBtn.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.submitBtn.Location = new System.Drawing.Point(126, 262);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(160, 40);
            this.submitBtn.TabIndex = 4;
            this.submitBtn.Text = "Ingresar";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cuitErrorLbl
            // 
            this.cuitErrorLbl.AutoSize = true;
            this.cuitErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.cuitErrorLbl.Location = new System.Drawing.Point(156, 165);
            this.cuitErrorLbl.Name = "cuitErrorLbl";
            this.cuitErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.cuitErrorLbl.TabIndex = 5;
            this.cuitErrorLbl.Visible = false;
            // 
            // passwordErrorLbl
            // 
            this.passwordErrorLbl.AutoSize = true;
            this.passwordErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.passwordErrorLbl.Location = new System.Drawing.Point(153, 232);
            this.passwordErrorLbl.Name = "passwordErrorLbl";
            this.passwordErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.passwordErrorLbl.TabIndex = 6;
            this.passwordErrorLbl.Visible = false;
            // 
            // Bienvenidos
            // 
            this.Bienvenidos.AutoSize = true;
            this.Bienvenidos.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.Bienvenidos.Location = new System.Drawing.Point(155, 54);
            this.Bienvenidos.Name = "Bienvenidos";
            this.Bienvenidos.Size = new System.Drawing.Size(102, 22);
            this.Bienvenidos.TabIndex = 7;
            this.Bienvenidos.Text = "Bienvenidos";
            // 
            // MenuInicio
            // 
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Bienvenidos);
            this.Controls.Add(this.passwordErrorLbl);
            this.Controls.Add(this.cuitErrorLbl);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.passwordTbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cuitTbox);
            this.Controls.Add(this.label1);
            this.Name = "MenuInicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cuitTbox;
        private System.Windows.Forms.TextBox passwordTbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label cuitErrorLbl;
        private System.Windows.Forms.Label passwordErrorLbl;
        private System.Windows.Forms.Label Bienvenidos;
    }
}

