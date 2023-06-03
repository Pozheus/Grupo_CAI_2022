using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_C_CAI.Modelos
{
    public class Tarifa
    {
        public string Tipo { get; set; }
        public List<CategoriaSegunPeso> CategoriasSegunPeso { get; set; }

        public static decimal Cotizar(SolicitudServicio solicitud)
        {
            string tipoDestino = solicitud.TipoDestino();
            decimal precio = 0;

            if (tipoDestino == "internacional")
            {
                precio = CotizarEnvioInternacional(solicitud);
            } else
            {
                precio = CotizarEnvioNacional(solicitud);
            }

            return precio;
        }

        private static decimal CotizarEnvioInternacional(SolicitudServicio solicitudInternacional)
        {
            Sucursal sucursalDestino = DB.TraerSucursales().First(x => x.Tipo == "centroDistribucion" && x.Ciudad == "CABA");

            SolicitudServicio servicioHastaCABA = new SolicitudServicio()
            {
                PaisOrigen = solicitudInternacional.PaisOrigen,
                ProvinciaOrigen = solicitudInternacional.ProvinciaOrigen,
                LocalidadOrigen = solicitudInternacional.LocalidadOrigen,
                DireccionOrigen = solicitudInternacional.DireccionOrigen,
                PaisDestino = sucursalDestino.Pais,
                ProvinciaDestino = sucursalDestino.Provincia,
                DireccionDestino = sucursalDestino.Direccion,
                LocalidadDestino = sucursalDestino.Localidad,
                PesoGramos = solicitudInternacional.PesoGramos,
                TipoEnvio = solicitudInternacional.TipoEnvio
            };

            decimal precioServicioNacional = CotizarEnvioNacional(servicioHastaCABA);
            decimal precioServicioInternacional = precioServicioNacional + solicitudInternacional.PaisDestino.RegionInternacional.CalcularRecargo(precioServicioNacional);

            return precioServicioInternacional;
        }

        private static decimal CotizarEnvioNacional(SolicitudServicio solicitud)
        {
            decimal precioNacional = 0;

            List<Tarifa> tarifasPosibles = DB.TraerTarifas();
            Tarifa tarifaSegunDestino = tarifasPosibles.Find(t => t.Tipo == solicitud.TipoDestino());


            precioNacional += tarifaSegunDestino.CategoriasSegunPeso.Find(x => x.MaximoGramos >= solicitud.PesoGramos).Precio;
            precioNacional += solicitud.TipoEnvio.CalcularRecargo(precioNacional);

            return precioNacional;
        }

        public class CategoriaSegunPeso
        {
            public int MaximoGramos { get; set; }
            public int Precio { get; set; }
        }
    }
}
