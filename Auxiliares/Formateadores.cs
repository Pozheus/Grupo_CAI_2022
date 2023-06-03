using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Auxiliares
{
    public static class Formateador
    {
        private static CultureInfo cultureInfo = new CultureInfo("es-AR");
        public static string FormatearImporte(decimal importe)
        {
            return string.Format(cultureInfo, "{0:c2} {1}", importe, new RegionInfo("es-AR").ISOCurrencySymbol);
        }
    }
}
