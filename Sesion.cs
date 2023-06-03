using Grupo_C_CAI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI
{
    static class Sesion
    {
        public static Cliente cliente { get; set; }
        public static Pais PaisOperacion { get { return DB.TraerPaises().Find(x => x.Nombre == "Argentina"); } }
    }
}
