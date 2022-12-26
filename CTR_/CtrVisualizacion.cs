using DAO_;
using DTO;
using DTO.Visualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
    public class CtrVisualizacion
    {
        private readonly DaoVisualizacion daoVisualizacion;

        public CtrVisualizacion()
        {
            daoVisualizacion = new DaoVisualizacion();
        }

        public void GuardarVisualizacionUsuario(DtoVisualizacion dtoVisualizacion)
        {
            try
            {
                daoVisualizacion.GuardarVisualizacionUsuario(dtoVisualizacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<DTOProductoVendido> ObtenerProductosVendidos()
        {
            try
            {
                return daoVisualizacion.ObtenerProductosVendidos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DTOVentaCatalogoDashboard ObtenerVentasPorCatalogo()
        {
            try
            {
                return daoVisualizacion.ObtenerVentasCatalogo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DTOVentaPersonalizadaDashboard ObtenerVentasPersonalizadas()
        {
            try
            {
                return daoVisualizacion.ObtenerVentasPersonalizadas();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DTOVentaDashboard> ObtenerVentasPorMes()
        {
            try
            {
                return daoVisualizacion.ObtenerVentasPorMes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DTOVentaAnualDashboard> ObtenerVentasAnuales()
        {
            try
            {
                return daoVisualizacion.ObtenerVentasAnuales();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DTOIngresosTotalDashboard ObtenerIngresosTotales()
        {
            try
            {
                return daoVisualizacion.ObtenerIngresosTotales();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DTOIngresoDashboard ObtenerIngresos()
        {
            try
            {
                return daoVisualizacion.ObtenerIngresos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DTOVisualizacionDashboard ObtenerVisualizaciones()
        {
            try
            {
                return daoVisualizacion.ObtenerVisualizaciones();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
