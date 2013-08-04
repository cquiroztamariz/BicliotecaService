using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServicios.Dominio
{
    [DataContract]
    public class Prestamo
    {
        [DataMember]
        public int IdPrestamo { get; set; }
        [DataMember]
        public Usuario Usuario { get; set; }
        [DataMember]
        public Publicacion Publicacion { get; set; }
        [DataMember]
        public DateTime FeSolicitud { get; set; }
        [DataMember]
        public int NuDias { get; set; }
        [DataMember]
        public string DeAprobo { get; set; }
        [DataMember]
        public DateTime? FeRespuesta { get; set; }
        [DataMember]
        public string DeSituacion { get; set; }
        [DataMember]
        public DateTime? FeInicio { get; set; }
        [DataMember]
        public DateTime? FeFin { get; set; }
        [DataMember]
        public DateTime? FeEntrega { get; set; }
        [DataMember]
        public DateTime? FeDevolucion { get; set; }
        [DataMember]
        public string TxObservacion { get; set; }
    }
}