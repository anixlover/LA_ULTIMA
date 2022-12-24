using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using CTR;
using WEB;

namespace Pruebas_Unitaria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRegistroClienteUE()
        {
            var RegistrarCLienteUE = new Formulario_web1();
            var objUsuario = new DtoUsuario();
            objUsuario.PK_VU_Dni = "73615397";
            objUsuario.VU_Nombre = "Mirko";
            objUsuario.VU_Apellidos = "Rojas";
            objUsuario.IU_Celular = 977830888;
            objUsuario.DTU_FechaNac = Convert.ToDateTime("07/04/2000");
            objUsuario.VU_Correo = "mirkorojas12@hotmail.com";
            objUsuario.VU_Contrasenia = "12345678";
            objUsuario.FK_ITU_Cod = 1;
            RegistrarCLienteUE.RegistrarUE(objUsuario);
        }
    }
}
