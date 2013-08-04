using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RESTServicios.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace RESTServicios.Persistencia
{
    public class PrestamoDAO : BaseDAO<Prestamo, int>
    {
        public ICollection<Prestamo> ListaSolicitudesPendientes()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                //ICriteria busqueda = sesion.CreateCriteria(typeof(Prestamo));
                ICriteria busqueda = sesion.CreateCriteria(typeof(Prestamo)).Add(Expression.Eq("DeSituacion", "Pendiente"));
                return busqueda.List<Prestamo>();
            }
        }

        public ICollection<Prestamo> ListaSolicitudesAnuladas()
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                //ICriteria busqueda = sesion.CreateCriteria(typeof(Prestamo));
                ICriteria busqueda = sesion.CreateCriteria(typeof(Prestamo)).Add(Expression.Eq("DeSituacion", "Anulada"));
                return busqueda.List<Prestamo>();
            }
        }
    }
}