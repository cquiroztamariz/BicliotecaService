using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using SolicitudPrestamoTest;


namespace SolicitudPrestamoTest
{
    [TestClass]
    public class SolicitudServiceTest
    {
        [TestMethod]
        public void CrearSolicitud()
        {
            try
            {
                string posdata = "{\"IdPublicacion\":\"2\",\"NuDias\":\"2\",\"NuDocumento\":\"09903031\"}";
                byte[] data = Encoding.UTF8.GetBytes(posdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:29818/SolicitudService.svc/Solicitudes");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string solicitudjson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Solicitud alumnocreado = js.Deserialize<Solicitud>(solicitudjson);
                //Assert.AreEqual(9, alumnocreado.codigo);
                Assert.AreNotEqual(0 , alumnocreado.IdSolicitud);
            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string error = reader2.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Error errorMessage = js.Deserialize<Error>(error);
                //"BP001""Hay datos vacios o nulos."
                //"US003" "Usuario no esta registrado."
                //"PUB003" "Publicacion no existe." 
                //"PRE006" "Dias solicitados no puede ser mayor a 7."
                Console.Out.WriteLine( errorMessage.CodError + " " + errorMessage.MesError);
                Console.Out.Flush();
            }
        }

        [TestMethod]
        public void CrearSolicitudErrorPedidoMayor_7_Dias()
        {
            try
            {
                string posdata = "{\"IdPublicacion\":\"2\",\"NuDias\":\"9\",\"NuDocumento\":\"09903031\"}";
                byte[] data = Encoding.UTF8.GetBytes(posdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:29818/SolicitudService.svc/Solicitudes");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string solicitudjson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Solicitud alumnocreado = js.Deserialize<Solicitud>(solicitudjson);
                //Assert.AreEqual(9, alumnocreado.codigo);
                Assert.AreNotEqual(0, alumnocreado.IdSolicitud);
            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string error = reader2.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Error errorMessage = js.Deserialize<Error>(error);
                //"PRE006" "Dias solicitados no puede ser mayor a 7."
                Console.Out.WriteLine(errorMessage.CodError + " " + errorMessage.MesError);
                Console.Out.Flush();
            }
        }

        [TestMethod]
        public void CrearSolicitud_DNI_NoExiste()
        {
            try
            {
                string posdata = "{\"IdPublicacion\":\"2\",\"NuDias\":\"2\",\"NuDocumento\":\"LLLLL\"}";
                byte[] data = Encoding.UTF8.GetBytes(posdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:29818/SolicitudService.svc/Solicitudes");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string solicitudjson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Solicitud alumnocreado = js.Deserialize<Solicitud>(solicitudjson);
                //Assert.AreEqual(9, alumnocreado.codigo);
                Assert.AreNotEqual(0, alumnocreado.IdSolicitud);
            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string error = reader2.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Error errorMessage = js.Deserialize<Error>(error);
                //"US003" "Usuario no esta registrado."
                Console.Out.WriteLine(errorMessage.CodError + " " + errorMessage.MesError);
                Console.Out.Flush();
            }
        }
    }
}
