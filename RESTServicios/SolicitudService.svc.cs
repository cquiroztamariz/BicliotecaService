using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTServicios.Persistencia;
using RESTServicios.Dominio;
using System.ServiceModel.Web;
using System.Net;

namespace RESTServicios
{
    public class SolicitudService : ISolicitudService
    {
        private PrestamoDAO prestamoDAO = null;
        private PrestamoDAO PrestamoDAO
        {
            get
            {
                if (prestamoDAO == null)
                    prestamoDAO = new PrestamoDAO();
                return prestamoDAO;
            }
        }

        private PublicacionDAO publicacionDAO = null;
        private PublicacionDAO PublicacionDAO
        {
            get
            {
                if (publicacionDAO == null)
                    publicacionDAO = new PublicacionDAO();
                return publicacionDAO;
            }
        }

        private UsuarioDAO usuarioDAO = null;
        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();
                return usuarioDAO;
            }
        }

        public Solicitud RegistrarSolicitud(Solicitud solicitudrecibida)
        {
            try
            {
                Solicitud solicitud = new Solicitud()
                {
                    IdPublicacion = solicitudrecibida.IdPublicacion,
                    NuDias = solicitudrecibida.NuDias,
                    NuDocumento = solicitudrecibida.NuDocumento
                };

                if (solicitud.NuDocumento == null || solicitud.NuDocumento.Length == 0 || solicitud.IdPublicacion == 0 || solicitud.NuDias == 0)
                {
                    throw new WebFaultException<Error>(
                        new Error() { CodError = "BP001", MesError = "Hay datos vacios o nulos." },
                    HttpStatusCode.BadRequest);
                }
                else
                {
                    Usuario usuario = new Usuario() { NuDocumento = solicitud.NuDocumento };
                    if (UsuarioDAO.BuscarxDNI(usuario) == 0)
                    {
                        throw new WebFaultException<Error>(
                            new Error() { CodError = "US003", MesError = "Usuario no esta registrado." },
                            HttpStatusCode.NotFound);
                    }
                    else
                    {
                        usuario = usuarioDAO.ObtenerxDNI(usuario);
                    }

                    Publicacion publicacion = new Publicacion();
                    publicacion = PublicacionDAO.Obtener(solicitud.IdPublicacion);
                    if ( publicacion== null)
                    {
                        throw new WebFaultException<Error>(
                            new Error() { CodError = "PUB003", MesError = "Publicacion no existe." },
                            HttpStatusCode.Conflict);
                    }

                    if (solicitud.NuDias > 7)
                    {
                        throw new WebFaultException<Error>(
                            new Error() { CodError = "PRE006", MesError = "Dias solicitados no puede ser mayor a 7." },
                            HttpStatusCode.NotAcceptable);
                    }

                    DateTime dd = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    Prestamo prestamo = new Prestamo()
                    {
                        Usuario = usuario,
                        Publicacion = publicacion,
                        NuDias = solicitud.NuDias,
                        DeSituacion="Pendiente",
                        FeSolicitud=dd,
                        FeDevolucion=null,
                        FeEntrega=null,
                        FeFin=null,
                        FeInicio=null,
                        FeRespuesta=null
                    };
                    
                    Prestamo solicitudcreada = new Prestamo();
                    solicitudcreada=PrestamoDAO.Crear(prestamo);
                    solicitud.IdSolicitud = solicitudcreada.IdPrestamo;
                    return solicitud;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Solicitud ObtenerSolicitud(string idsolicitud)
        {
            try
            {
                if (Convert.ToInt32(idsolicitud) == 0)
                {
                    throw new WebFaultException<Error>(
                        new Error() { CodError = "BP001", MesError = "Hay datos vacios o nulos." },
                    HttpStatusCode.BadRequest);
                }
                else
                {
                    Prestamo solicitudAObtener = new Prestamo();
                    solicitudAObtener = PrestamoDAO.Obtener(Convert.ToInt32(idsolicitud));

                    if (solicitudAObtener == null)
                    {
                        throw new WebFaultException<Error>(
                            new Error() { CodError = "PRE003", MesError = "Numero de Solicitud no existe." },
                            HttpStatusCode.NotFound);
                    }
                    else
                    {
                        Solicitud solicitud = new Solicitud()
                        {
                            IdSolicitud = solicitudAObtener.IdPrestamo,
                            IdPublicacion = solicitudAObtener.Publicacion.IdPublicacion,
                            NuDocumento = solicitudAObtener.Usuario.NuDocumento,
                            NuDias = solicitudAObtener.NuDias,
                            DeSituacion = solicitudAObtener.DeSituacion
                        };
                        return solicitud;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AnularSolicitud(string idsolicitud)
        {
            try
            {
                if (Convert.ToInt32(idsolicitud) == 0)
                {
                    throw new WebFaultException<Error>(
                        new Error() { CodError = "BP001", MesError = "Hay datos vacios o nulos." },
                    HttpStatusCode.BadRequest);
                }
                else
                {
                    Prestamo solicitudAAnular = new Prestamo();
                    solicitudAAnular = PrestamoDAO.Obtener(Convert.ToInt32(idsolicitud));

                    if (solicitudAAnular == null)
                    {
                        throw new WebFaultException<Error>(
                            new Error() { CodError = "PRE003", MesError = "Numero de Solicitud no existe." },
                            HttpStatusCode.NotFound);
                    }
                    else
                    {
                        if (solicitudAAnular.DeSituacion != "Pendiente")
                        {
                            throw new WebFaultException<Error>(
                                new Error() { CodError = "PRE004", MesError = "Solicitud no puede ser Anulada porque ya fue procesada!!." },
                                HttpStatusCode.NotAcceptable);
                        }
                        solicitudAAnular.DeSituacion = "Anulada";
                        prestamoDAO.Modificar(solicitudAAnular);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Prestamo> ListarSolicitudesAnuladas()
        {
            return PrestamoDAO.ListaSolicitudesAnuladas().ToList();
        }

        public List<Prestamo> ListarSolicitudesPendientes()
        {
            return PrestamoDAO.ListaSolicitudesPendientes().ToList();
        }
    }
}
