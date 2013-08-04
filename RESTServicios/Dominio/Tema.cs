using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Tema
    {
        [DataMember]
        public int IdTema { get; set; }
        [DataMember]
        public string DeTema { get; set; }
        [DataMember]
        public Materia Materia { get; set; }
    }
}