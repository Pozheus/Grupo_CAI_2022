using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Password { get; set; }
        public Provincia Provincia { get { return BuscarProvincia(); } }
        public string Region { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public Pais Pais { get { return BuscarPais(); } }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public int ProvinciaId { get; set; }
        public int PaisId { get; set; }

        private Pais _pais { get; set; }
        private Provincia _provincia { get; set; }

        private Provincia BuscarProvincia()
        {
            if (_provincia == null)
            {
                _provincia = DB.TraerProvincias().Find(x => x.Id == ProvinciaId);
            }

            return _provincia;
        }

        private Pais BuscarPais()
        {
            if (_pais == null)
            {
                _pais = DB.TraerPaises().Find(x => x.Id == PaisId);
            }

            return _pais;
        }
    }
}
