using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SolicitudPrestamoTest
{
    
    public class Solicitud
    {
        public string DeSituacion { get; set; }
        public int IdPublicacion { get; set; }
        public int IdSolicitud { get; set; }
        public int NuDias { get; set; }
        public string NuDocumento { get; set; }
    }
}