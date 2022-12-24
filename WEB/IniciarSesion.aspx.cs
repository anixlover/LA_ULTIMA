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
    public partial class IniciarSesion : System.Web.UI.Page
    {
        SqlConnection conexion;
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        //NO TOCAR EXPLOTA
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
            }
        }

        DtoUsuario usr = new DtoUsuario();
        Log log = new Log();

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDNI.Text;
                
                string pass = txtContraseña.Text;
                //string epass = GetSHA256(pass);

                if (string.IsNullOrEmpty(dni))
                {
                    throw new Exception("Ingrese su usuario");
                }
                if (string.IsNullOrEmpty(pass))
                {
                    throw new Exception("Ingrese su clave");
                }
                DtoUsuario usuarioDto = new DtoUsuario();
                CtrUsuario usuarioCtr = new CtrUsuario();

                usuarioDto.PK_VU_Dni = dni;
                usuarioDto.VU_Contrasenia = pass;

                usuarioDto = usuarioCtr.Login(usuarioDto);
                log.CustomWriteOnLog("Login_V2", "usuarioDto" + usuarioDto);
                if (usuarioDto != null)
                {
                    log.CustomWriteOnLog("Login_V2", "-------------------------------------------------------------------------------------------------------------");
                    log.CustomWriteOnLog("Login_V2", "-----------------------------Ingresando a login y seteando valores de session--------------------------------");
                    log.CustomWriteOnLog("Login_V2", "-------------------------------------------------------------------------------------------------------------");

                    Session["DNIUsuario"] = usuarioDto.PK_VU_Dni;
                    Session["NombreUsuario"] = usuarioDto.VU_Nombre;
                    Session["ApellidosUsuario"] = usuarioDto.VU_Apellidos;
                    Session["CorreoUsuario"] = usuarioDto.VU_Correo;
                    Session["id_perfil"] = usuarioDto.FK_ITU_Cod;
                    Session["FechaNacUsuario"] = usuarioDto.DTU_FechaNac;
                    Session["CelularUsuario"] = usuarioDto.IU_Celular;
                    Session["Contrasenia"] = pass;

                    log.CustomWriteOnLog("Login_V2", " Session['DNIUsuario'] " + Session["DNIUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['NombreUsuario'] " + Session["NombreUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['ApellidosUsuario'] " + Session["ApellidosUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['CorreoUsuario'] " + Session["CorreoUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['id_perfil'] " + Session["id_perfil"]);
                    log.CustomWriteOnLog("Login_V2", " Session['FechaNacUsuario'] " + Session["FechaNacUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['CelularUsuario'] " + Session["CelularUsuario"]);
                    log.CustomWriteOnLog("Login_V2", " Session['Contrasenia'] " + Session["Contrasenia"]);
                    log.CustomWriteOnLog("Login_V2", "--------------------------------------------Fin Login Aspx----------------------------------------------------");

                    //CLIENTE
                    if (Session["id_perfil"].ToString() == "1")
                    {
                        HttpCookie returnCookie = Request.Cookies["returnUrl"];
                        if ((returnCookie == null) || string.IsNullOrEmpty(returnCookie.Value))
                        {
                            string script = @"<script type='text/javascript'>
                                      location.href='../Inspeccionar_Catalogo.aspx';
                                  </script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                        }

                        else
                        {
                            HttpCookie deleteCookie = new HttpCookie("returnUrl");
                            deleteCookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(deleteCookie);
                            Response.Redirect(returnCookie.Value);
                        }

                    }
                    //VENDEDOR
                    else if (Session["id_perfil"].ToString() == "2")
                    {

                        string script = @"<script type='text/javascript'>
                                      location.href='../RegistrarClienteVendedor.aspx';
                                  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                    }
                    //TRABAJADOR
                    else if (Session["id_perfil"].ToString() == "3")
                    {

                        string script = @"<script type='text/javascript'>
                                       location.href='../EvaluarPedidosPersonalizados.aspx';
                                  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                    }
                    //GERENTE
                    else if (Session["id_perfil"].ToString() == "4")
                    {

                        string script = @"<script type='text/javascript'>
                                      location.href='../Administrar_Pedido.aspx';
                                  </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);

                    }

                }
                else
                {

                    //mostrarMensaje.Text = "Su usuario o contraseña incorrecta o no existe";
                    //throw new Exception("Su usuario o contraseña incorrecta o no existe");
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Usuario o contraseña INCORRECTOS!!'});", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                log.CustomWriteOnLog("Login_V2", "Error = " + ex.Message + "stack" + ex.StackTrace);
                string script = "alert(\"Usuario o contraseña incorrecta\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}