using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Net.Mail;
using System.Net;

namespace WEB
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DtoUsuario objDtoUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text == "" | txtApellidos.Text == "" | txtCelular.Text == "" | txtCorreo.Text == "" | txtFechNac.Text == "")//<----Control de espacion vacios o Nulos
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            objDtoUsuario.PK_VU_Dni = txtDNI.Text;
            objDtoUsuario.VU_Nombre = txtNombres.Text;
            objDtoUsuario.VU_Apellidos = txtApellidos.Text;
            objDtoUsuario.IU_Celular = int.Parse(txtCelular.Text);
            objDtoUsuario.DTU_FechaNac = Convert.ToDateTime(txtFechNac.Text);
            objDtoUsuario.VU_Correo = txtCorreo.Text;
            objDtoUsuario.FK_ITU_Cod = 1;
            RegistrarVendedor(objDtoUsuario);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'});", true);
            EnviarCorreo(objDtoUsuario);
        }
        public void RegistrarVendedor(DtoUsuario objUsuario)//<----Metodo de Registro
        {
            if (objCtrUsuario.formatoDni(objUsuario) == false) //Probar si el Dni introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Dni INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoNombre(objUsuario) == false)//Probar si el Nombre introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Nombre INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoApellido(objUsuario) == false)//Probar si el Apellido introducido cumple con el formato
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Apellido INVALIDO!!'});", true);
                return;
            }
            if (objCtrUsuario.formatoCorreo(objUsuario) == false)//Probar si el correo introducido cumple con el formato
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
            //Registra al usuario tipo cliente y redirije al iniciarsesion.aspx
            objCtrUsuario.RegistrarClienteVendedor(objUsuario);            
        }
        public void EnviarCorreo(DtoUsuario objDtoUsuario)
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
            string body =
                "<body>" +
                    "<h1>DECORMOLDURAS & ROSETONES SAC</h1>" +
                    "<h4>Bienvenid@ " + objDtoUsuario.VU_Nombre + "</h4>" +
                    "<span>No comparta esto con nadie." +
                    "<br></br><span>Su contraseña es: " + objDtoUsuario.VU_Contrasenia + "</span>" +
                    "<br></br><span> Saludos cordiales.<span>" +
                "</body>";

            MailMessage mail = new MailMessage();
            mail.Subject = "Bienvenido";
            mail.From = new MailAddress(Emisor.Trim(), displayName);
            mail.Body = body;
            mail.To.Add(new MailAddress(Receptor));
            mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.Normal;

            //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
            NetworkCredential nc = new NetworkCredential(Emisor, EmisorPass);
            smtp.Credentials = nc;
            smtp.Send(mail);
        }
    }
}