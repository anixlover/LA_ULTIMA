using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using DAO;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace WEB
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        DtoUsuario objUsuario = new DtoUsuario();
        Log _log = new Log();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtContraseña.Text == "" | txtFechNac.Text == "")//<----Control de espacion vacios o Nulos
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            objUsuario.PK_VU_Dni = txtDNI.Text;
            objUsuario.VU_Nombre = txtNombres.Text;
            objUsuario.VU_Apellidos = txtApellidos.Text;
            objUsuario.IU_Celular = int.Parse(txtCelular.Text);
            objUsuario.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
            objUsuario.VU_Correo = txtCorreo.Text;
            objUsuario.VU_Contrasenia = txtContraseña.Text;
            objUsuario.FK_ITU_Cod = 1;
            RegistrarUE(objUsuario);
            //objUsuario.IU_CodigoActivacion = GenerarCodigoToken();
            //string ActivationUrl = Server.HtmlEncode("http://localhost:49533/WebPrincipal/ActivarCuenta.aspx?UserID=" + objUsuario.PK_VU_Dni + "&EmailId=" + objUsuario.VU_Correo);
        }
        public void RegistrarUE(DtoUsuario objUsuario)//<----Metodo de Registro
        {
            if (objCtrUsuario.formatoDni(objUsuario) == false | txtDNI.Text.Contains("000")) //Probar si el Dni introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Dni INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoNombre(objUsuario) == false | txtNombres.Text.Contains(" "))//Probar si el Nombre introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoApellido(objUsuario) == false | txtApellidos.Text.Contains(" "))//Probar si el Apellido introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoCorreo(objUsuario) == false | txtCorreo.Text.Contains(" "))//Probar si el correo introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Correo INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaDni(objUsuario))//probar si el DNI introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Dni DUPLICADO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCelular(objUsuario))//probar si el Número de celular introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Número de celular DUPLICADO!!'});", true);
                return;
            }
            if (objCtrUsuario.existenciaCorreo(objUsuario))//probar si el Correo introducido ya estaba registrado en la base de dato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Correo DUPLICADO!!'});", true);
                return;
            }
            if (DateTime.Now.Year - objUsuario.DTU_FechaNac.Year < 18)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Fecha INVALIDA!!'});", true);
                return;
            }
            //Registra al usuario tipo cliente y redirije al iniciarsesion.aspx
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='IniciarSesion.aspx'})", true);
            objCtrUsuario.RegistrarClienteUsuarioExterno(objUsuario);


            string ActivationUrl = Server.HtmlEncode("https://localhost:44363/IniciarSesion.aspx");
            string FilePath = "E:\\LA_ULTIMA\\WEB\\EmailTemplate\\htmlActivarCuenta.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("{NombreUsuario}", objUsuario.VU_Nombre + " " + objUsuario.VU_Apellidos);

            EnviarCorreo(txtCorreo.Text, "CuentaRegistrada", MailText);
        }
        protected int GenerarCodigoToken()
        {
            int min = 100000;
            int max = 1000000;
            Random rnd = new Random();
            int value = rnd.Next(min, max);

            return value;
        }
        public void EnviarCorreo(string CuentaCorreo, string Asunto, string cuerpoMensaje)
        {
            try
            {
                String userName = "decormoldurassac2022@hotmail.com";
                String password = "Decormoldurassac1";
                MailMessage msg = new MailMessage(userName, CuentaCorreo);
                MailAddress copy = new MailAddress(userName);
                msg.Subject = Asunto;
                msg.Body = cuerpoMensaje;
                msg.IsBodyHtml = true;
                msg.CC.Add(copy);
                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.Credentials = new System.Net.NetworkCredential(userName, password);

                // SmtpClient.Host = "smtp.gmail.com";

                SmtpClient.Host = "smtp.office365.com";

                SmtpClient.Port = 587;
                SmtpClient.EnableSsl = true;
                SmtpClient.Send(msg);
                _log.CustomWriteOnLog("EnviarCorreo", "Enviado");


                //string ActivationUrl = Server.HtmlEncode("https://localhost:44363/IniciarSesion.aspx");
                //string FilePath = "E:\\LA_ULTIMA\\WEB\\EmailTemplate\\htmlActivarCuenta.html";
                //StreamReader str = new StreamReader(FilePath);
                //string MailText = str.ReadToEnd();
                //str.Close();

                //MailText = MailText.Replace("{NombreUsuario}", objUsuario.VU_Nombre + " " + objUsuario.VU_Apellidos);


                //MailText = MailText.Replace("{URLENLACE}", ActivationUrl);

            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
                _log.CustomWriteOnLog("EnviarCorreo", "Error : " + ep.Message);
            }
        }

        protected void EnviarCorreo_Click(object sender, EventArgs e)
        {
            
        }
    }
}