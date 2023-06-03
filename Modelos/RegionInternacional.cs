using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class RegionInternacional
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Recargo { get; set; }

        public decimal CalcularRecargo(decimal precioBase)
        {
            return precioBase + Recargo;
        }
    }
}
