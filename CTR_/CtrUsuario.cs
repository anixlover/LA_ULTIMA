using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DAO;
using DTO;

namespace CTR
{
    public class CtrUsuario
    {
        DaoUsuario objDaoUsuario;
        public CtrUsuario()
        {
            objDaoUsuario = new DaoUsuario();
        }
        //DNI solo tiene números
        public bool formatoDni(DtoUsuario objUsuario)
        {
            string letras = "";
            bool correcto = true;            
            string usuarioDni = objUsuario.PK_VU_Dni;
            for (int i = 0; i < usuarioDni.Trim().Length; i++)
            {
                correcto = char.IsDigit(usuarioDni.Trim()[i]);
                if (!correcto)
                {
                    letras += usuarioDni.Trim()[i];
                }
            }
            if(letras.Length>0)
            {
                return false;
            }
            else
            return correcto;
        }
        //Nombre solo tiene letras
        public bool formatoNombre(DtoUsuario objUsuario)
        {
            string numeros = "";
            bool correcto = true;
            string usuarioNom = objUsuario.VU_Nombre;
            for (int i = 0; i < usuarioNom.Trim().Length; i++)
            {
                correcto = char.IsLetter(usuarioNom.Trim()[i]);
                if (!correcto)
                {
                    numeros += usuarioNom.Trim()[i];
                }
            }
            if (numeros.Length > 0)
            {
                return false;
            }
            return correcto;
        }
        //Apellido solo tiene letras
        public bool formatoApellido(DtoUsuario objUsuario)
        {
            string numeros = "";
            bool correcto = true;
            string usuarioApe = objUsuario.VU_Apellidos;
            for (int i = 0; i < usuarioApe.Trim().Length; i++)
            {
                correcto = char.IsLetter(usuarioApe.Trim()[i]);
                if (!correcto)
                {
                    numeros += usuarioApe.Trim()[i];
                }
            }
            if (numeros.Length > 0)
            {
                return false;
            }
            return correcto;
        }
        //Validación del formato del correo
        public bool formatoCorreo(DtoUsuario objUsuario)
        {
            bool correcto = true;
            string usuarioCor = objUsuario.VU_Correo;
            string Expression = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            correcto = Regex.IsMatch(usuarioCor, Expression);
            return correcto;
        }
        //existe DNI=true ^ NO existe DNI=false
        public bool existenciaDni(DtoUsuario objUsuario)
        {
            return objDaoUsuario.SelectUsuarioxDni(objUsuario);
        }
        //existe Correo=true ^ NO existe Correo=false
        public bool existenciaCorreo(DtoUsuario objUsuario)
        {
           return objDaoUsuario.SelectUsuarioxCorreo(objUsuario);
        }
        //existe número de Celular=true ^ NO existe número de Celular=false
        public bool existenciaCelular(DtoUsuario objUsuario)
        {
            return objDaoUsuario.SelectUsuarioxCelular(objUsuario);
        }
        //Creación de contraseña automática
        public string GenerarContraseña(DtoUsuario objUsuario)
        {
            DateTime Hoy = DateTime.Today;
            string contraseña = Hoy.Year.ToString() + objUsuario.PK_VU_Dni.Trim()[4] + objUsuario.PK_VU_Dni.Trim()[5] + objUsuario.PK_VU_Dni.Trim()[6] + objUsuario.PK_VU_Dni.Trim()[7] + Hoy.Month.ToString();
            return contraseña;
        }
        //Registro del cliente
        //         |
        //         V
        public void RegistrarClienteUsuarioExterno(DtoUsuario objUsuario)
        {
            objDaoUsuario.InsertUsuarioCliente(objUsuario);
        }        
        public void RegistrarClienteVendedor(DtoUsuario objUsuario)
        {
            objUsuario.VU_Contrasenia = GenerarContraseña(objUsuario);
            objDaoUsuario.InsertUsuarioCliente(objUsuario);
        }
        public bool ValidarInicioSesion(DtoUsuario objUsuario)
        {
            return objDaoUsuario.SelectUsuarioxDni_Contraseña(objUsuario);
        }

        public bool ValidarUsuarioxDni_Correo_Celular(DtoUsuario dtoUsuario)
        {
            return objDaoUsuario.SelectUsuarioxDni_Correo_Celular(dtoUsuario);
        }
        public void CambiarContraseña(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.UpdateContraseña(dtoUsuario);
        }

        public DtoUsuario Login(DtoUsuario dtoUsuario)
        {

            int persona_id = objDaoUsuario.validacionLogin(dtoUsuario.PK_VU_Dni, dtoUsuario.VU_Contrasenia);

            if (persona_id == 0)
            {
                throw new Exception("Usuario y/o contrase&ntilde;a incorrecta(s)");
            }
            else
            {
                return objDaoUsuario.datosUsuario(dtoUsuario.PK_VU_Dni);
            }
        }

        public void ActualizarDatos(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.UptadeDatosPerfil(dtoUsuario);
        }
        public void EnviarCorreoReportado(DtoSolicitud dtomxu)
        {
            objDaoUsuario.EnviarCorreoReportado(dtomxu);
        }
       
        public void TraeData(DtoUsuario dtoUsuario)
        {
            objDaoUsuario.TraeData(dtoUsuario);
        }

    }
}
