using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Net.Mail;
using System.Net;

namespace WEB
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtContraseña.Visible = false;
                txtContraseña2.Visible = false;
                btnContraseña.Visible = false;
                btnEnviar.Visible = true;
                txtpass1.Visible = false;
                txtpass2.Visible = false;
                if (Request.Params["act"] != null)
                {
                    objUsuario.PK_VU_Dni = Request.Params["act"].ToString();
                    if (objCtrUsuario.existenciaDni(objUsuario) == true)
                    {
                        btnContraseña.Visible = true;
                        txtContraseña.Visible = true;
                        txtContraseña2.Visible = true;
                        btnEnviar.Visible = false;
                        txtCorreo.Visible = false;
                        txtpass1.Visible = true;
                        txtpass2.Visible = true;
                    }
                }
            }
        }

        protected void btnContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña2.Text == "" | txtContraseña.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!!',text: 'Espacios en BLANCO!!'});", true);
                return;
            }
            objUsuario.PK_VU_Dni = Request.Params["act"];
            objUsuario.VU_Correo = txtCorreo.Text;
            if (txtContraseña.Text != txtContraseña2.Text)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'las contraseñas deben coincidir!!'});", true);
                return;
            }
            objUsuario.VU_Contrasenia = txtContraseña.Text;           
            objCtrUsuario.CambiarContraseña(objUsuario);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Cambio EXITOSO!',text: 'Contraseña actualizada!!'}).then(function(){window.location.href='IniciarSesion.aspx'});", true);
        }
        public void EnviarCorreo(DtoUsuario objDtoUsuario, string body)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            string Emisor = "decormoldurasyrosetonessac@gmail.com";
            string EmisorPass = "decor$molduras$";
            string displayName = "DECORMOLDURAS & ROSETONES SAC";
            string Receptor = objDtoUsuario.VU_Correo;
            string htmlbody = body;            
            MailMessage mail = new MailMessage();
            mail.Subject = "Bienvenido";
            mail.From = new MailAddress(Emisor.Trim(), displayName);
            mail.Body = htmlbody;
            mail.To.Add(new MailAddress(Receptor));
            mail.IsBodyHtml = true;
            NetworkCredential nc = new NetworkCredential(Emisor, EmisorPass);
            smtp.Credentials = nc;
            smtp.Send(mail);
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!txtCorreo.Equals(null))
            {
                objUsuario.VU_Correo = txtCorreo.Text;
                if (objCtrUsuario.existenciaCorreo(objUsuario))
                {
                    string body = "<body>" +
                       "<h1>DECORMOLDURAS & ROSETONES SAC</h1>" +
                       "<h4>Bienvenid@ " + objUsuario.VU_Nombre + "</h4>" +
                       "<span>No comparta esto con nadie." +
                       "<br></br><span>link de confirmación: " + "https://localhost:44363/CambiarContraseña.aspx?act=" + objUsuario.PK_VU_Dni + "<span>"+
                       "<br></br><span> Saludos cordiales.<span>" +
                   "</body>";
                    EnviarCorreo(objUsuario,body);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Revisa tu correo!',text: 'Link de confirmación enviada!!'});", true);
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'Correo no existente!',text: 'Porfavor ingresar su correo!!'});", true);
            }
        }

        protected void btnCancelar1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IniciarSesion.aspx");
        }
    }
}