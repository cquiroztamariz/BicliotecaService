using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using RESTServicios.Dominio;

namespace RESTServicios
{
    [ServiceContract]
    public interface ISolicitudService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Solicitudes", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Solicitud RegistrarSolicitud(Solicitud solicitud);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Solicitudes/{idsolicitud}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Solicitud ObtenerSolicitud(string idsolicitud);
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "Solicitudes/Solicitud")]
        bool AnularSolicitud(string idsolicitud);
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "Solicitudes/Anuladas")]
        List<Prestamo> ListarSolicitudesAnuladas();
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "Solicitudes/Pendientes")]
        List<Prestamo> ListarSolicitudesPendientes();
    }
}
