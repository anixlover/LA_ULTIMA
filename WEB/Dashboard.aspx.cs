using CTR;
using DTO.Visualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class Dashboard : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static DTOVisualizacionDashboard ObtenerVisualizaciones()
        {
             var ctrVisualizacion = new CtrVisualizacion();

             var visualizaciones = ctrVisualizacion.ObtenerVisualizaciones();

            return visualizaciones;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static DTOVentaCatalogoDashboard ObtenerVentasPorCatalogo()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ventasPorCatalogo = ctrVisualizacion.ObtenerVentasPorCatalogo();

            return ventasPorCatalogo;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static DTOVentaPersonalizadaDashboard ObtenerVentasPersonalizadas()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ventasPersonalizadas = ctrVisualizacion.ObtenerVentasPersonalizadas();

            return ventasPersonalizadas;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static DTOIngresoDashboard ObtenerIngresos()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ventasPersonalizadas = ctrVisualizacion.ObtenerIngresos();

            return ventasPersonalizadas;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<DTOVentaAnualDashboard> ObtenerVentasAnuales()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ventas = ctrVisualizacion.ObtenerVentasAnuales();

            return ventas;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<DTOVentaDashboard> ObtenerVentasPorMes()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ventas = ctrVisualizacion.ObtenerVentasPorMes();

            return ventas;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static DTOIngresosTotalDashboard ObtenerIngresosTotales()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var ingresosTotales = ctrVisualizacion.ObtenerIngresosTotales();

            return ingresosTotales;
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<DTOProductoVendido> ObtenerProductosVendidos()
        {
            var ctrVisualizacion = new CtrVisualizacion();

            var productosVendidos = ctrVisualizacion.ObtenerProductosVendidos();

            return productosVendidos;
        }
    }
}