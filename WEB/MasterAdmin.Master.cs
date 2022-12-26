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
    public partial class MasterAdmin : System.Web.UI.MasterPage
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
                        userTrabajador();
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
                Response.Redirect("~/IniciarSesion.aspx");
            }

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
        public void perfilGerente()
        {
            string html = string.Format(@"
                            <li>
                                <a href='Dashboard.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Analisis de Venta</span>
                                </a>
                            </li>
                            <li>
                                <a href='Gestionar_Catalogo.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Gestionar Catalogo</span>
                                </a>
                            </li>
                            <li>
                                <a href='EvaluarPedidosPersonalizados.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Evaluar Pedidos Personalizados</span>
                                </a>
                            </li>
                            <li>
                                <a href='ReporteVentas.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Generar Reporte Ventas</span>
                                </a>
                            </li>
                            <li>
                                <a href='IniciarSesion.aspx' class='collapse' runat='server' onserverclick='btnCerrarSesion_ServerClick>
                                    <i data-feather='book-open'></i>
                                    <span>Cerrar Sesión</span>
                                </a>
                            </li>

        ");
            this.Literal1.Text = html;
        }
        public void perfilVendedor()
        {
            string html = string.Format(@"
                           <li>     
                                <a href='Administrar_Pedido.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Administrar Pedido</span>
                                </a>
                            </li>
                            <li>     
                                <a href='Realizar_Venta2.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Realizar Venta</span>
                                </a>
                            </li>
                            <li>     
                                <a href='Ingresa_Venta.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Ingreso de Venta</span>
                                </a>
                            </li>
                            <li>     
                                <a href='ReporteStockMoldura.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Generar Reporte Stock</span>
                                </a>
                            </li>
                            <li>     
                                <a href='RegistrarClienteVendedor.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Registrar Cliente</span>
                                </a>
                            </li>
                            <li>
                                <a href='IniciarSesion.aspx' class='collapse' runat='server' onserverclick='btnCerrarSesion_ServerClick>
                                    <i data-feather='book-open'></i>
                                    <span>Cerrar Sesión</span>
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
        public void userTrabajador()
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
                           <li>     
                                <a href='GestionarEstadosPedido.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Gestionar Estado Pedido</span>
                                </a>
                            </li>
                            <li>     
                                <a href='GestionarMolde.aspx' class='collapse'>
                                    <i data-feather='book-open'></i>
                                    <span>Gestionar Molde</span>
                                </a>
                            </li>
                            <li>
                                <a href='IniciarSesion.aspx' class='collapse' runat='server' onserverclick='btnCerrarSesion_ServerClick>
                                    <i data-feather='book-open'></i>
                                    <span>Cerrar Sesión</span>
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
            //Session.Clear();
            //Session.Abandon();
            //Response.Redirect("~/Login.aspx");
            Session.Clear();
            Session.Remove("id_perfil");
            Session.Abandon();
            HttpContext.Current.Session.Abandon();
            Session.RemoveAll();
            Session["id_perfil"] = null;
            Response.Redirect("~/IniciarSesion.aspx");
        }





    }
}