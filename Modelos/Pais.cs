using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int RegionInternacionalId { get; set; }
        public RegionInternacional RegionInternacional { get { return BuscarRegionInternacional(); } }
        private RegionInternacional _regionInternacional { set; get; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pais p = (Pais)obj;
                return p.Id == Id;
            }
        }

        public override string ToString()
        {
            return Nombre;
        }

        private RegionInternacional BuscarRegionInternacional()
        {
            if (_regionInternacional == null)
            {
                _regionInternacional = DB.TraerRegionesInternacionales().Find(x => x.Id == RegionInternacionalId);
            }

            return _regionInternacional;
        }
    }
}
