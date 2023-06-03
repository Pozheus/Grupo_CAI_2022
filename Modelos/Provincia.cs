using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Provincia p = (Provincia)obj;
                return p.Id == Id;
            }
        }
    }
}
