using System.Windows.Forms;
using System.Linq;
using Grupo_C_CAI.Modelos;
using System.Collections.Generic;

namespace Grupo_C_CAI
{
    public partial class MenuInicio : Form
    {
        private Cliente cliente {  get; set; }

        public MenuInicio()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            LimpiarMensajesError();

            string cuit = cuitTbox.Text;
            string password = passwordTbox.Text;

            this.cliente = DB.TraerClientePorCUIT(cuit);

            if (ValidarInicioSesion())
            {
                this.Hide();
                Sesion.cliente = this.cliente;
                MostrarMenuPrincipal();
            } else
            {
                cuitErrorLbl.Show();
                passwordErrorLbl.Show();
            }
        }

        private bool ValidarInicioSesion()
        {
            bool valido = true;

            if (this.cuitTbox.Text.Length == 0)
            {
                cuitErrorLbl.Text = "El CUIT no puede estar vacio.";
                valido = false;
            }

            if (this.passwordTbox.Text.Length == 0)
            {
                passwordErrorLbl.Text = "La contraseña no puede estar vacia.";
                valido = false;
            }

            if (!valido) { return valido; }

            if (this.cliente == null)
            {
                cuitErrorLbl.Text = "El CUIT no se encuentra registrado.";
                valido = false;
            } else
            {
                if (this.passwordTbox.Text != this.cliente.Password)
                {
                    passwordErrorLbl.Text = "La contraseña es incorrecta.";
                    valido = false;
                }
            }

            return valido;
        }

        private void MostrarMenuPrincipal()
        {
            MenuPrincipal m = new MenuPrincipal();
            m.Show();
        }

        private void LimpiarMensajesError()
        {
            cuitErrorLbl.Text = "";
            passwordErrorLbl.Text = "";
        }
    }
}
