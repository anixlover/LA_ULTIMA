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
    }
}