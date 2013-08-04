using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Autor
    {
        [DataMember]
        public int IdAutor { get; set; }
        [DataMember]
        public string DeAutor { get; set; }
    }
}
