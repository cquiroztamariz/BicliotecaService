using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string CodError { get; set; }
        [DataMember]
        public string MesError { get; set; }
    }
}