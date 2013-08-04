using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServicios.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            //return "Data Source=(local);Initial Catalog=BibliotecaPublica;Integrated Security=SSPI;";
            return "Data Source=f4a06890-b16a-4fa8-8310-a20f005172bf.sqlserver.sequelizer.com;Initial Catalog=dbf4a06890b16a4fa88310a20f005172bf;User Id=oohebqkdfanepohu;Password=8xgchJum22mjmLnZpHKVPpEAEjLEjJEjR5djAP58nfrmzo5HVP3b7DhSZME66Xcr;";
        }
    }
}