using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTServicios.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace RESTServicios.Persistencia
{
    public class UsuarioDAO : BaseDAO<Usuario, int>
    {
        public int BuscarxDNI(Usuario usuario)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Usuario)).Add(Expression.Eq("NuDocumento", usuario.NuDocumento)).SetProjection(Projections.RowCount());
                if ((int)busqueda.List()[0] > 0)
                    return 1;
                return 0;
            }
        }

        public Usuario ObtenerxDNI(Usuario usuario)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Usuario)).Add(Expression.Eq("NuDocumento", usuario.NuDocumento));
                return busqueda.UniqueResult<Usuario>();
            }
        }

        public int BuscarxCorreo(Usuario usuario)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Usuario)).Add(Expression.Eq("DeCorreo", usuario.DeCorreo)).SetProjection(Projections.RowCount());
                if ((int)busqueda.List()[0] > 0)
                    return 1;
                return 0;
            }
        }

        public Usuario ObtenerxCorreo(Usuario usuario)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Usuario)).Add(Expression.Eq("DeCorreo", usuario.DeCorreo));
                return busqueda.UniqueResult<Usuario>();
            }
        }
    }
}