using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Materia
    {
        [DataMember]
        public int IdMateria { get; set; }
        [DataMember]
        public string DeMateria { get; set; }
    }
}