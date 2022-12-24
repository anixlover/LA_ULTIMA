using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DtoMxUIncidente
    {
        public int PK_IMXUI_Cod { get; set; }
        public DateTime DTMXUI_Fecha { get; set; }
        public int VMXU_Incidente { get; set; }
        public string FK_VMU_Dni { get; set; }
        public int FK_IMU_Cod { get; set; }
    }
}
