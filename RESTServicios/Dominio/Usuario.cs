using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string DeNombre { get; set; }

        [DataMember]
        public string DeApellido { get; set; }

        [DataMember]
        public string NuDocumento { get; set; }

        [DataMember]
        public string DeDireccion { get; set; }

        [DataMember]
        public string DeDistrito { get; set; }

        [DataMember]
        public string DeCorreo { get; set; }

        [DataMember]
        public string DeSituacion { get; set; }
    }
}