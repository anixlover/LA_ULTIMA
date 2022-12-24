using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CTR;
using DTO;

namespace WEB
{
    public partial class Administrar_Solicitud_Pedido : System.Web.UI.Page
    {
        DtoMolduraXUsuario objDtoMXU = new DtoMolduraXUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        DtoMoldura objDtoMoldura = new DtoMoldura();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}