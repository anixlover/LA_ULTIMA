using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace WEB
{
    public partial class Master_RV : System.Web.UI.MasterPage
    {
        Log Log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                Log.WriteOnLog("-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
                Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
                int perfil = int.Parse(Session["id_perfil"].ToString());

                switch (perfil)
                {
                    case 2://vendedor
                        perfilVendedor();
                        userVendedor();
                        break;

                    case 3://trabajador
                        perfilTrabajador();
                        break;
                    case 4://gerente
                        perfilGerente();
                        userGerente();
                        break;

                    default:
                        Session.Clear();
                        Session.Abandon();
                        HttpContext.Current.Session.Abandon();
                        Session.RemoveAll();
                        Response.Redirect("~/IniciarSesion.aspx");
                        break;

                }
            }
            catch (Exception ex)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }

        }
        public void perfilGerente()
        {
            string html = string.Format(@"
            <li class=''>
                        <a href='Administrar_Pedido.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Administrar Pedido</span>
                        </a>
                    </li>
            <li>
                        <a href='Realizar_Venta2.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Realizar Venta</span>
                        </a>
                    </li>
        ");
            this.Literal1.Text = html;
        }
        public void userGerente()
        {
            string nombre = Session["NombreUsuario"].ToString();

            string html = string.Format(
               @"
            <a class='nav-link dropdown-toggle nav-user mr-0 waves-effect waves-light' data-toggle='dropdown' href='#' role='button' aria-haspopup='false' aria-expanded='false'>" +
                                "<span class=pro-user-name ml-1>" +
                                    "Hola " + nombre + "<i class='mdi mdi-chevron-down'></i>" +
                                "</span>" +
                            "</a>" +
                            "<div class='dropdown-menu dropdown-menu-right profile-dropdown'>" +
                                "<a id='btnCerrarSesion' href='IniciarSesion.aspx' runat='server' onserverclick='btnCerrarSesion_ServerClick' class='dropdown-item notify-item'>" +
                                    "<i class='fe-log-out'></i>" +
                                    "<span>Cerrar Sesión</span>" +
                                "</a>" +
                            "</div>");
            this.Literal2.Text = html;
        }
        public void perfilVendedor()
        {
            string html = string.Format(@"
            <li class=''>
                        <a href='RegistrarClienteVendedor.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Registrar Cliente</span>
                        </a>
                    </li>
            <li>
                        <a href='Realizar_Venta2.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Realizar Venta</span>
                        </a>
                    </li>
            <li>
                        <a href='Administrar_Pedido.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Administrar Pedidos</span>
                        </a>
                    </li>
        ");
            this.Literal1.Text = html;
        }
        public void userVendedor()
        {
            string nombreusr = Session["NombreUsuario"].ToString();

            string html = string.Format(
                @"
            <a class='nav-link dropdown-toggle nav-user mr-0 waves-effect waves-light' data-toggle='dropdown' href='#' role='button' aria-haspopup='false' aria-expanded='false'>" +
                                "<span class=pro-user-name ml-1>" +
                                    "Hola " + nombreusr + "<i class='mdi mdi-chevron-down'></i>" +
                                "</span>" +
                            "</a>" +
                            "<div class='dropdown-menu dropdown-menu-right profile-dropdown'>" +
                                "<a id='btnCerrarSesion' href='IniciarSesion.aspx' runat='server' onserverclick='btnCerrarSesion_ServerClick' class='dropdown-item notify-item'>" +
                                    "<i class='fe-log-out'></i>" +
                                    "<span>Cerrar Sesión</span>" +
                                "</a>" +
                            "</div>");
            this.Literal2.Text = html;
        }
        public void perfilTrabajador()
        {
            string html = string.Format(@"
            <li class='active'>
                        <a href='Gestionar_Estado_Pedido.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Gestionar Estado Pedido</span>
                        </a>
                    </li>
          
        ");
            this.Literal1.Text = html;
        }
        protected void UsuarioOption_ServerClick(object sender, EventArgs e)
        {

        }

        protected void AdministradorOption_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }

}