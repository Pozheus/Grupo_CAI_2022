using System;
using Grupo_C_CAI.Auxiliares;
using System.Linq;
using Newtonsoft.Json;

namespace Grupo_C_CAI.Modelos
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SolicitudServicio
    {
        [JsonProperty]
        public int Id { get; set; }

        private int _id { get; set; } = 0;

        [JsonProperty]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Datos del envio
        [JsonProperty]
        public int PaisOrigenId { get; set; }
        public Pais PaisOrigen { get; set; }

        [JsonProperty]
        public int ProvinciaOrigenId { get; set; }
        public Provincia ProvinciaOrigen { get; set; }

        [JsonProperty]
        public string LocalidadOrigen { get; set; }

        [JsonProperty]
        public string DireccionOrigen { get; set; }

        [JsonProperty]
        public string CodigoPostalOrigen { get; set; }

        [JsonProperty]
        public int TipoEnvioId { get; set; }
        public TipoEnvio TipoEnvio { get; set; }

        [JsonProperty]
        public int PesoGramos { get; set; }

        // Datos del destinatario

        [JsonProperty]
        public int PaisDestinoId { get; set; }
        public Pais PaisDestino { get; set; }

        [JsonProperty]
        public int ProvinciaDestinoId { get; set; }
        public Provincia ProvinciaDestino { get; set; }

        [JsonProperty]
        public string DireccionDestino { get; set; }

        [JsonProperty]
        public string LocalidadDestino { get; set; }

        public string TipoEntrega { get; set; }

        [JsonProperty]
        public string TelefonoContacto { get; set; }
        
        [JsonProperty]
        public decimal Precio { get; set; }
        public string PrecioFormateado { get { return Formateador.FormatearImporte(Precio); } }

        [JsonProperty]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty]
        public string CodigoPostalDestino { get; set; }

        [JsonProperty]
        public string EstadoDestino { get; set; }

        [JsonProperty]
        public string Estado { get; set; }

        [JsonProperty]
        public int FacturaId { get; set; }

        public virtual string NombreConDatos { get { return GenerarNombreConDatos(); } }

        public string TipoDestino()
        {
            if (PaisDestino.Id != PaisOrigen.Id)
            {
                return "internacional";
            }

            if (ProvinciaDestino.Region != ProvinciaOrigen.Region)
            {
                return "nacional";
            }

            if (ProvinciaDestino.Id != ProvinciaOrigen.Id)
            {
                return "regional";
            }

            if (LocalidadDestino.ToLower() != LocalidadOrigen.ToLower())
            {
                return "provincial";
            }

            return "local";
        }

        public bool GuardarEnDB()
        {
            Id = ObtenerNuevoId();

            return DB.InsertarSolicitudServicio(this);
        }

        private int ObtenerNuevoId()
        {
            var solicitudes = DB.TraerSolicitudesServicio();

            if (solicitudes.Count > 0)
            {
                _id = solicitudes.Last().Id + 1;
            } else
            {
                return 1;
            }

            return _id;
        }

        private string GenerarNombreConDatos()
        {
            Pais pais = DB.TraerPaises().Find(x => x.Id == PaisDestinoId);
            Provincia provincia = DB.TraerProvincias().Find(x => x.Id == ProvinciaDestinoId);

            string nombre = $"ID: # { Id } - { FechaCreacion.ToLocalTime() } - Destino: { pais.Nombre }";
            nombre = nombre + $" { (provincia != null ? provincia.Nombre : EstadoDestino) }, { LocalidadDestino }, { DireccionDestino }";
            nombre = nombre + $"- { PrecioFormateado }";

            return nombre;
        }
    }
}