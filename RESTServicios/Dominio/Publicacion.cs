using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Publicacion
    {
        [DataMember]
        public int IdPublicacion { get; set; }
        [DataMember]
        public string DePublicacion { get; set; }
        [DataMember]
        public string FePublicacion { get; set; }
        [DataMember]
        public string TxEdicion { get; set; }
        [DataMember]
        public Autor Autor { get; set; }
        [DataMember]
        public Tema Tema { get; set; }
        [DataMember]
        public string DeEstado { get; set; }
    }
}