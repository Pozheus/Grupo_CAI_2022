using Grupo_C_CAI.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool Pagada { get; set; }
        public List<SolicitudServicio> Solicitudes { get { return BuscarSolicitudesAsociadas(); } }
        public string NombreConDatos { get { return GenerarNombreConDatos(); } }
        public virtual decimal Monto { get { return CalcularMonto(); } }
        public virtual string MontoFormateado { get { return Formateador.FormatearImporte(Monto); } }

        private List<SolicitudServicio> BuscarSolicitudesAsociadas()
        {
            return DB.TraerSolicitudesServicio().Where(x => x.FacturaId == Id).ToList();
        }

        private string GenerarNombreConDatos()
        {
            string nombre = $"ID: # { Id } - { FechaEmision.ToLocalTime() } - { MontoFormateado } - { (Pagada ? "Pagada" : "Adeuda") }";

            return nombre;
        }

        private decimal CalcularMonto()
        {
            return Solicitudes.Sum(x => x.Precio);
        }
    }
}
