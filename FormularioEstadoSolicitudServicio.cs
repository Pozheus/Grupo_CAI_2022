using Grupo_C_CAI.Modelos;
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
    public partial class FormularioEstadoSolicitudServicio : Form
    {
        public FormularioEstadoSolicitudServicio()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InicializarListaSolicitudes();
        }

        private void InicializarListaSolicitudes()
        {
            List<SolicitudServicio> solicitudes = DB.TraerSolicitudesServicio().Where(x => x.ClienteId == Sesion.cliente.Id).ToList();
            solicitudesListBox.DataSource = solicitudes;
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().Show();
        }

        private void solicitudesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            estadoLbl.Text = ((sender as ListBox).SelectedItem as SolicitudServicio).Estado;
        }
    }
}
