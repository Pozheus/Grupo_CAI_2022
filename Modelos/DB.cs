using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Grupo_C_CAI.Modelos
{
    class DB
    {
        public static List<Cliente> TraerClientes()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/clientes.json";

            return TraerEntidades<Cliente>(ruta);
        }

        public static Cliente TraerClientePorCUIT(string cuit)
        {
            List<Cliente> clientes = TraerClientes();
            Cliente cliente = clientes.Find(x => x.CUIT == cuit);

            return cliente;
        }

        public static List<Tarifa> TraerTarifas()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/tarifas.json";

            return TraerEntidades<Tarifa>(ruta);
        }

        public static List<Sucursal> TraerSucursales()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/sucursales.json";

            return TraerEntidades<Sucursal>(ruta);
        }

        public static List<Pais> TraerPaises()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/paises.json";

            return TraerEntidades<Pais>(ruta);
        }

        public static List<RegionInternacional> TraerRegionesInternacionales()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/regionesInternacionales.json";

            return TraerEntidades<RegionInternacional>(ruta);
        }

        public static List<Provincia> TraerProvincias()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/provincias.json";

            return TraerEntidades<Provincia>(ruta);
        }

        public static List<TipoEnvio> TraerTiposEnvio()
        {
            string ruta = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/tiposEnvio.json";

            return TraerEntidades<TipoEnvio>(ruta);
        }

        public static bool InsertarSolicitudServicio(SolicitudServicio solicitud)
        {
            string rutaMaestro = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/solicitudes.json";

            return InsertarEntidad(solicitud, rutaMaestro);
        }

        public static List<Factura> TraerFacturas()
        {
            string rutaMaestro = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/facturas.json";

            return TraerEntidades<Factura>(rutaMaestro);
        }

        public static List<SolicitudServicio> TraerSolicitudesServicio()
        {
            string rutaMaestro = $"{AppDomain.CurrentDomain.BaseDirectory}/../../Datos/solicitudes.json";

            return TraerEntidades<SolicitudServicio>(rutaMaestro);
        }

        private static bool InsertarEntidad<T>(T entidad, string rutaMaestro)
        {
            List<T> entidades = TraerEntidades<T>(rutaMaestro);
            entidades.Add(entidad);
            string json = JsonConvert.SerializeObject(entidades);

            StreamWriter w = new StreamWriter(rutaMaestro);
            w.Write(json);
            w.Close();

            return true;
        }

        private static List<T> TraerEntidades<T>(string rutaMaestro)
        {
            StreamReader r = new StreamReader(rutaMaestro);
            string jsonString = r.ReadToEnd();
            List<T> entidades = JsonConvert.DeserializeObject<List<T>>(jsonString);

            r.Close();

            return entidades;
        }
    }
}
