using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DTO;
using CTR;
using System.Security.Cryptography;
using System.Text;

namespace WEB
{
    public partial class Autentificacion : System.Web.UI.Page
    {
        SqlConnection conexion;
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.Remove("id_perfil");
                Session.Abandon();
                HttpContext.Current.Session.Abandon();
                Session.RemoveAll();
                Session["id_perfil"] = null;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Autentificación Exitosa!',text: 'Inicie Sesión!!'}).then(function(){window.location.href='IniciarSesion.aspx'})", true);
                //Response.Redirect("~/IniciarSesion.aspx");
            }
        }
    }
}