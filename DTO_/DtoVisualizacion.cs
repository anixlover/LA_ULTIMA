using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoVisualizacion
    {
        public DtoVisualizacion() {  }

        public DtoVisualizacion(string vS_NombreModulo, DateTime dTS_FechaRegistro, string vS_Maquina)
        {
            VS_NombreModulo = vS_NombreModulo;
            DTS_FechaRegistro = dTS_FechaRegistro;
            VS_Maquina = vS_Maquina;
        }

        public int PK_IV_Cod { get; set; }
        public string VS_NombreModulo { get; set; }
        public DateTime DTS_FechaRegistro { get; set; }
        public string VS_Maquina { get; set; }
    }
}
