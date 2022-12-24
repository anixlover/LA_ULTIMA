using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DtoUsuario
    {
        public string PK_VU_Dni { get; set; }
        public string VU_Nombre { get; set; }
        public string VU_Apellidos { get; set; }
        public int IU_Celular { get; set; }
        public DateTime DTU_FechaNac { get; set; }
        public string VU_Correo { get; set; }
        public string VU_Contrasenia { get; set; }
        public int FK_ITU_Cod { get; set; }
    }
}
