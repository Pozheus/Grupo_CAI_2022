using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_C_CAI
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void generarSolicitudBtn_Click(object sender, EventArgs e)
        {
            MostrarFormularioSolicitudServicio();
        }

        private void MostrarFormularioSolicitudServicio()
        {
            this.Hide();
            FormularioSolicitudServicio f = new FormularioSolicitudServicio();
            f.Show();
        }

        private void MostrarFormularioEstadoSolicitudServicio()
        {
            this.Hide();
            new FormularioEstadoSolicitudServicio().Show();
        }

        private void MostrarFormularioEstadoCuentaCorriente()
        {
            this.Hide();
            new FormularioEstadoCuentaCorriente().Show();
        }

        private void estadoSolicitudServiciobtn_Click(object sender, EventArgs e)
        {
            MostrarFormularioEstadoSolicitudServicio();
        }

        private void estadoCuentaCorrienteBtn_Click(object sender, EventArgs e)
        {
            MostrarFormularioEstadoCuentaCorriente();
        }
    }
}
