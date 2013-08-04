using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Solicitud
    {
        [DataMember]
        public string DeSituacion { get; set; }
        [DataMember]
        public int IdPublicacion { get; set; }
        [DataMember]
        public int IdSolicitud { get; set; }
        [DataMember]
        public int NuDias { get; set; }
        [DataMember]
        public string NuDocumento { get; set; }
    }
}