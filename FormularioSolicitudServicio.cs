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
using Grupo_C_CAI.Auxiliares;
using System.Text.RegularExpressions;

namespace Grupo_C_CAI
{
    public partial class FormularioSolicitudServicio : Form
    {
        private Cliente cliente = Sesion.cliente;
        private SolicitudServicio solicitud = new SolicitudServicio() { Cliente = Sesion.cliente };
        private List<Provincia> provincias = DB.TraerProvincias();
        private List<Pais> paises = DB.TraerPaises();
        private List<Sucursal> sucursales = DB.TraerSucursales();

        #region Controladores
        public FormularioSolicitudServicio()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            AutocompletarDatosCliente();
            RellenarProvincias();
            RellenarPaises();
            RellenarSucursales();
        }

        private void RellenarSucursales()
        {
            sucursalOrigenCmb.DataSource = DB.TraerSucursales().ToList();
            sucursalOrigenCmb.SelectedIndex = -1;

            sucursalDestinoCmb.DataSource = DB.TraerSucursales().ToList();
            sucursalDestinoCmb.SelectedIndex = -1;
        }

        private void RellenarProvincias()
        {
            provinciaOrigenCmb.DataSource = DB.TraerProvincias();
            provinciaDestinoCmb.DataSource = DB.TraerProvincias();
        }

        private void RellenarPaises()
        {
            paisDestinoCmb.DataSource = paises;
        }

        private void RellenarSolicitud(SolicitudServicio solicitud)
        {
            solicitud.Cliente = cliente;
            solicitud.ClienteId = cliente.Id;

            solicitud.PaisOrigenId = Sesion.PaisOperacion.Id;
            solicitud.PaisOrigen = Sesion.PaisOperacion;
            solicitud.ProvinciaOrigenId = (provinciaOrigenCmb.SelectedItem as Provincia).Id;
            solicitud.ProvinciaOrigen = provinciaOrigenCmb.SelectedItem as Provincia;
            solicitud.LocalidadOrigen = localidadOrigenTbox.Text;
            solicitud.DireccionOrigen = direccionOrigenTbox.Text;
            solicitud.CodigoPostalOrigen = codigoPostalOrigenTbox.Text;

            solicitud.PesoGramos = int.Parse(pesoGroup.Controls.OfType<RadioButton>().First(radio => radio.Checked).Tag.ToString());

            solicitud.TipoEnvio = DB.TraerTiposEnvio().Find(x => x.Nombre == tipoEnvioGroup.Controls.OfType<RadioButton>().First(radio => radio.Checked).Tag.ToString());
            solicitud.TipoEnvioId = solicitud.TipoEnvio.Id;

            solicitud.PaisDestinoId = (paisDestinoCmb.SelectedItem as Pais).Id;
            solicitud.PaisDestino = paisDestinoCmb.SelectedItem as Pais;
            solicitud.ProvinciaDestino = provinciaDestinoCmb.SelectedItem as Provincia;

            if (solicitud.ProvinciaDestino != null)
            {
                solicitud.ProvinciaDestinoId = (provinciaDestinoCmb.SelectedItem as Provincia).Id;
            } else
            {
                solicitud.EstadoDestino = estadoDestinoTbox.Text.ToString();
            }

            solicitud.LocalidadDestino = localidadDestinoTbox.Text;
            solicitud.DireccionDestino = direccionDestinoTbox.Text;
            solicitud.CodigoPostalDestino = codigoPostalDestinoTbox.Text;
            solicitud.TelefonoContacto = telefonoContactoTbox.Text;

            solicitud.FechaCreacion = DateTime.Now;
            solicitud.Estado = "Pendiente";

            solicitud.Precio = Tarifa.Cotizar(solicitud);
        }

        private void AutocompletarDatosCliente()
        {
            cuitTbox.Text = cliente.CUIT;
            razonSocialTbox.Text = cliente.RazonSocial;
            emailTbox.Text = cliente.Email;
        }

        private void MostrarConfirmacionSolicitudServicio()
        {
            string message = "¡Solicitud generada con éxito!";
            string title = "Confirmación de Solicitud de Servicio";
            var result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            new MenuPrincipal().Show();
        }

        private void HabilitarDatosDestinatario()
        {
            bool datosCompletados = ValidarGrupoRadioButtons(pesoGroup) &&
                        ValidarGrupoRadioButtons(puntoRecoleccionGroup) &&
                        ValidarGrupoRadioButtons(tipoEnvioGroup);

            bool direccionOrigenCompletada = sucursalOrigenCmb.Enabled ? sucursalOrigenCmb.SelectedIndex != -1 : true;

            datosDestinatarioGroup.Enabled = datosCompletados && direccionOrigenCompletada;
        }

        #endregion

        #region Validaciones
        private bool ValidarFormulario()
        {
            bool[] validaciones = new bool[]
            {
                ValidarPesoGroup(),
                ValidarTipoEnvio(),
                ValidarPuntoRecoleccion(),
                ValidarSucursalOrigen(),
                ValidarTipoEntrega(),
                ValidarSucursalDestino(),
                ValidarPaisDestino(),
                ValidarProvinciaDestino(),
                ValidarLocalidadDestino(),
                ValidarDireccionDestino(),
                ValidarCodigoPostalDestino(),
                ValidarTelefonoContacto(),
                ValidarDireccionOrigenYDireccionDestino()
            };

            return validaciones.All(x => x == true);
        }

        private bool ValidarDireccionOrigenYDireccionDestino()
        {
            if ((paisDestinoCmb.SelectedItem as Pais).Id == (Sesion.PaisOperacion).Id)
            {
                bool coincideProvincia = (provinciaOrigenCmb.SelectedItem as Provincia).Id == (provinciaDestinoCmb.SelectedItem as Provincia).Id;
                bool coincideLocalidad = localidadOrigenTbox.Text.ToLower().Trim() == localidadDestinoTbox.Text.ToLower().Trim();
                bool coincideDireccion = direccionOrigenTbox.Text.ToLower().Trim() == direccionDestinoTbox.Text.ToLower().Trim();

                if (coincideProvincia && coincideLocalidad && coincideDireccion)
                {
                    MessageBox.Show("La dirección de destino es igual a la de origen. Revise los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            return true;
        }

        private bool ValidarGrupoRadioButtons(GroupBox group)
        {
            List<RadioButton> controles = new List<RadioButton>();

            foreach (RadioButton control in group.Controls.OfType<RadioButton>())
            {
                controles.Add(control);
            }

            bool radioSeleccionado = controles.Any(x => x.Checked);
            return radioSeleccionado;
        }

        private bool ValidarTextBox(TextBox textbox)
        {
            return textbox.Text.Length > 3 && textbox.Text.Length < 100;
        }

        private bool ValidarNumero(string texto)
        {
            return texto.Length < 40 && Regex.IsMatch(texto, @"\d");
        }

        private bool ValidarComboBox(ComboBox combo)
        {
            return !combo.Enabled || (combo.Enabled && combo.SelectedIndex != -1);
        }
        #endregion

        #region Eventos
        private void cotizarBtn_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                RellenarSolicitud(solicitud);
                submitBtn.Enabled = true;
            } else
            {
                solicitud.Precio = new decimal(0);
            }

            precioLbl.Text = solicitud.PrecioFormateado;
        }


        private void volverBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                RellenarSolicitud(solicitud);
                solicitud.GuardarEnDB();
                MostrarConfirmacionSolicitudServicio();
            }
        }

        private bool ValidarPesoGroup()
        {
            bool valido = ValidarGrupoRadioButtons(pesoGroup);

            pesoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarTipoEnvio()
        {
            bool valido = ValidarGrupoRadioButtons(tipoEnvioGroup);

            tipoEnvioErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarPuntoRecoleccion()
        {
            bool valido = ValidarGrupoRadioButtons(puntoRecoleccionGroup);
            puntoRecoleccionErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarSucursalOrigen()
        {
            bool valido = !sucursalOrigenCmb.Enabled || (sucursalOrigenCmb.Enabled && sucursalOrigenCmb.SelectedIndex != -1);
            sucursalOrigenErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarTipoEntrega()
        {
            bool valido = ValidarGrupoRadioButtons(tipoEntregaGroup);
            tipoEntregaErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarSucursalDestino()
        {
            bool valido = !sucursalDestinoCmb.Enabled || (sucursalDestinoCmb.Enabled && sucursalDestinoCmb.SelectedIndex != -1); ;
            sucursalDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarPaisDestino()
        {
            bool valido = ValidarComboBox(paisDestinoCmb);
            paisDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarProvinciaDestino()
        {
            bool valido = ValidarComboBox(provinciaDestinoCmb);
            provinciaDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarLocalidadDestino()
        {
            bool valido = ValidarTextBox(localidadDestinoTbox);
            localidadDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarDireccionDestino()
        {
            bool valido = ValidarTextBox(direccionDestinoTbox);
            direccionDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarCodigoPostalDestino()
        {
            string errorMsg = "";

            bool longitud = ValidarTextBox(codigoPostalDestinoTbox);
            bool numerico = ValidarNumero(codigoPostalDestinoTbox.Text);

            if (!longitud)
            {
                errorMsg = "Debe ser > 3 caracteres";
            } else if(!numerico) {
                errorMsg = "Debe ser numérico";
            }

            bool valido = longitud && numerico;
            codigoPostalDestinoErrorLbl.Text = errorMsg;
            codigoPostalDestinoErrorLbl.Visible = !valido;

            return valido;
        }

        private bool ValidarTelefonoContacto()
        {
            string errorMsg = "";

            bool longitud = ValidarTextBox(telefonoContactoTbox);
            bool numerico = ValidarNumero(telefonoContactoTbox.Text);

            if (!longitud)
            {
                errorMsg = "Debe ser > 3 caracteres";
            }
            else if (!numerico)
            {
                errorMsg = "Debe ser numérico";
            }

            bool valido = longitud && numerico;
            telefonoContactoErrorLbl.Text = errorMsg;
            telefonoContactoErrorLbl.Visible = !valido;

            return valido;
        }
        #endregion

        private void puntoRecoleccionSucursalRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            if (radio.Checked)
            {
                sucursalOrigenCmb.Enabled = true;
                sucursalOrigenCmb.SelectedIndex = -1;
                sucursalOrigenCmb.Text = "";

                provinciaOrigenCmb.SelectedItem = null;
                localidadOrigenTbox.Text = "";
                direccionOrigenTbox.Text = "";
                codigoPostalOrigenTbox.Text = "";
                HabilitarDatosDestinatario();
            }
        }
        private void puntoRecoleccionDomicilioRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            if (radio.Checked)
            {
                sucursalOrigenCmb.SelectedIndex = -1;
                sucursalOrigenCmb.Enabled = false;
                sucursalOrigenCmb.Text = "No corresponde";

                provinciaOrigenCmb.SelectedItem = cliente.Provincia;
                localidadOrigenTbox.Text = cliente.Localidad;
                direccionOrigenTbox.Text = cliente.Direccion;
                codigoPostalOrigenTbox.Text = cliente.CodigoPostal;
                HabilitarDatosDestinatario();
            }
        }

        private void sucursalOrigenCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sucursal sucursalSeleccionada = ((ComboBox)sender).SelectedItem as Sucursal;

            if (sucursalSeleccionada != null)
            {
                provinciaOrigenCmb.SelectedItem = sucursalSeleccionada.Provincia;
                localidadOrigenTbox.Text = sucursalSeleccionada.Localidad;
                direccionOrigenTbox.Text = sucursalSeleccionada.Direccion;
                codigoPostalOrigenTbox.Text = sucursalSeleccionada.CodigoPostal;
            }

            HabilitarDatosDestinatario();
        }

        private void tipoEntregaEnPuertaRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
            {
                sucursalDestinoCmb.Enabled = false;
                sucursalDestinoCmb.SelectedIndex = -1;
                sucursalDestinoCmb.Text = "No corresponde";

                paisDestinoCmb.Enabled = true;
                paisDestinoCmb.SelectedIndex = -1;

                provinciaDestinoCmb.Enabled = true;
                provinciaDestinoCmb.SelectedIndex = -1;

                localidadDestinoTbox.Enabled = true;
                localidadDestinoTbox.Text = "";

                direccionDestinoTbox.Enabled = true;
                direccionDestinoTbox.Text = "";

                codigoPostalDestinoTbox.Enabled = true;
                codigoPostalDestinoTbox.Text = "";

                telefonoContactoTbox.Enabled = true;
            }
        }

        private void tipoEntregaEnSucursalRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;

            if (radio.Checked)
            {
                sucursalDestinoCmb.Enabled = true;
                sucursalDestinoCmb.SelectedIndex = -1;
                sucursalDestinoCmb.Text = "";
                paisDestinoCmb.Enabled = false;
                provinciaDestinoCmb.Enabled = false;
                localidadDestinoTbox.Enabled = false;
                direccionDestinoTbox.Enabled = false;
                codigoPostalDestinoTbox.Enabled = false;
                telefonoContactoTbox.Enabled = true;
            }
        }

        private void sucursalDestinoCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            Sucursal sucursalSeleccionada = combo.SelectedItem as Sucursal;

            if (sucursalSeleccionada != null)
            {
                paisDestinoCmb.SelectedItem = sucursalSeleccionada.Pais;
                provinciaDestinoCmb.SelectedItem = sucursalSeleccionada.Provincia;
                localidadDestinoTbox.Text = sucursalSeleccionada.Localidad;
                direccionDestinoTbox.Text = sucursalSeleccionada.Direccion;
                codigoPostalDestinoTbox.Text = sucursalSeleccionada.CodigoPostal;
            }
        }

        private void paisDestinoCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            Pais paisSeleccionado = combo.SelectedItem as Pais;

            if (paisSeleccionado != null)
            {
                if (paisSeleccionado.Id != Sesion.PaisOperacion.Id)
                {
                    estadoDestinoTbox.Enabled = true;
                    estadoDestinoTbox.Visible = true;
                    estadoDestinoLbl.Visible = true;
                    provinciaDestinoCmb.Enabled = false;
                    provinciaDestinoCmb.Visible = false;
                    provinciaDestinoLbl.Visible = false;
                } else
                {
                    estadoDestinoTbox.Enabled = false;
                    estadoDestinoTbox.Visible = false;
                    estadoDestinoLbl.Visible = false;
                    provinciaDestinoCmb.Enabled = true;
                    provinciaDestinoCmb.Visible = true;
                    provinciaDestinoLbl.Visible = true;
                }
            }
        }

        private void tipoEnvioNormalRadio_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDatosDestinatario();
        }

        private void tipoEnvioUrgenteRadio_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDatosDestinatario();
        }

        private void provinciaDestinoCmb_EnabledChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;

            if (datosDestinatarioGroup.Enabled && combo.Enabled && !paisDestinoCmb.Enabled)
            {
                combo.Enabled = false;
            }
        }
    }
}
