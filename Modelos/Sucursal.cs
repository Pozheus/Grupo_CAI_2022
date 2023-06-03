using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public Provincia Provincia { get { return BuscarProvincia(); } }
        public Pais Pais { get { return BuscarPais(); } }
        private Provincia _provincia { get; set; }
        private Pais _pais { get; set; }
        public int PaisId { get; set; }
        public int ProvinciaId { get; set; }
        public string CodigoPostal { get; set; }

        public override string ToString()
        {
            return $"# { Id } - { Nombre.ToUpper() }";
        }

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
