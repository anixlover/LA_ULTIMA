using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DtoMolduraXUsuario
    {
        public string FK_VU_Dni { get; set; }
        public int FK_IM_Cod { get; set; }
        public int IMU_Cantidad { get; set; }
        public double DMU_Precio { get; set; }
        public int FK_IS_Cod { get; set; }
        public int FK_IMXUE_Cod { get; set; }
    }
}
