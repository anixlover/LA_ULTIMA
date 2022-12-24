using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class MasterCliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id_perfil"] == null)
                {
                    perfil_Socio();
                    Session.Clear();
                }
                else
                {
                    int perfil = int.Parse(Session["id_perfil"].ToString());
                    switch (perfil)
                    {
                        case 1:
                            perfil_Socio_Logeado();
                            break;
                        case 2:
                            break;
                        default:
                            perfil_Socio();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/IniciarSesion.aspx");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/IniciarSesion.aspx");
            }
        }
        public void perfil_Socio()
        {
            string html = string.Format(@"
                        <a id='login' class='nav-link dropdown-toggle nav-user mr-0 waves-effect waves-light' href='IniciarSesion.aspx'>

                            <i class='fe-log-in'></i>
                            <span class='pro-user-name ml-1'>Iniciar Sesión
                            </span>
                        </a>
                    ");
            this.Literal1.Text = html;
        }
        public void perfil_Socio_Logeado()
        {
            string nombreusuario = Session["NombreUsuario"].ToString();
            string dni = Session["DNIUsuario"].ToString();

            string html = string.Format(@"

                        <a class='nav-link dropdown-toggle nav-user mr-0 waves-effect waves-light' data-toggle='dropdown' href='#' role='button' aria-haspopup='false' aria-expanded='false'>
                                
                                <span class='pro-user-name ml-1'>
                                    Hola "+ nombreusuario + @"<i class='mdi mdi-chevron-down'></i> 
                                </span>
                            </a>
                        <div class='dropdown-menu dropdown-menu-right profile-dropdown'>
                                
                                <div class='dropdown-header noti-title'>
                                    <h6 class='text-overflow m-0'>Bienvenid@ !</h6>
                                </div>
                                <a href= 'Administrar_Perfil.aspx' id='btnAdministrarPerfil' runat='server' onClick='cargarId(" + dni + @")' class='dropdown-item notify-item'>
                                    <i class='fe-user'></i>
                                    <span>Perfil</span>
                                </a>
                                <a href= 'CambiarContraseña.aspx' id='btnCambiarContra' runat='server' onClick='cargarId(" + dni + @")' class='dropdown-item notify-item'>
                                    <i class='fe-user'></i>
                                    <span>Cambiar Contraseña</span>
                                </a>
                                <a href= 'ConsultarEstadosPago.aspx' id='btnPedidos' runat='server' onClick='cargarId(" + dni + @")' class='dropdown-item notify-item'>
                                    <i class='fe-user'></i>
                                    <span>Mis pedidos</span>
                                </a>
                                <a id='btnCerrarSesion' href='IniciarSesion.aspx' runat='server' onserverclick='btnCerrarSesion_ServerClick' class='dropdown-item notify-item'>
                                    <i class='fe-log-out'></i>
                                    <span>Cerrar Sesión</span>
                                </a>
    
                            </div>

                    ");
            this.Literal1.Text = html;
        }
        protected void btnCerrarSesion_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Remove("id_perfil");
            Session.Abandon();
            HttpContext.Current.Session.Abandon();
            Session.RemoveAll();
            Session["id_perfil"] = null;
            Response.Redirect("~/IniciarSesion.aspx");
            //Session.Clear();
            //Session.Abandon();
            //Response.Redirect("~/IniciarSesion.aspx");

        }

        //protected void btnPedido_Personalizado_ServerClick(object sender, EventArgs e)
        //{
        //    if (Session["DNIUsuario"] == null)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'No puede acceder al servicio!',text: 'Debe INICIAR SESION!!'}).then(function(){window.location.href='IniciarSesion.aspx'})", true);

        //    }

        //}

    }
}