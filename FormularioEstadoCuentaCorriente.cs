using Grupo_C_CAI.Auxiliares;
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
    public partial class FormularioEstadoCuentaCorriente : Form
    {
        private List<Factura> facturas = DB.TraerFacturas().Where(x => x.ClienteId == Sesion.cliente.Id).ToList();
        public FormularioEstadoCuentaCorriente()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SetearSaldo();
            InicializarListas();
        }

        private void SetearSaldo()
        {
            saldoLbl.Text = Formateador.FormatearImporte(facturas.Sum(x => x.Pagada ? 0 : -x.Monto));
        }

        private void InicializarListas()
        {
            facturasListBox.DataSource = facturas;
            solicitudesPendientesListBox.DataSource = DB.TraerSolicitudesServicio().Where(x => x.ClienteId == Sesion.cliente.Id && x.FacturaId == 0 && x.Estado == "Entregada").ToList();
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().Show();
        }

        private void detalleBtn_Click(object sender, EventArgs e)
        {
            Factura factura = facturasListBox.SelectedItem as Factura;

            string title = $"Factura ID #{ factura.Id }";
            string body = "Servicios facturados: \n\n";

            factura.Solicitudes.ForEach(x => body += ($"{x.NombreConDatos}\n\n"));

            body += $"\n\nImporte final: {factura.MontoFormateado}\n\n";

            MessageBox.Show(body, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
