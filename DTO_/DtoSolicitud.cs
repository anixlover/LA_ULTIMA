using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DtoSolicitud
    {
        public int PK_IS_Cod { get; set; }
        public string VS_TipoSolicitud { get; set; }
        public byte[] VBS_Imagen { get; set; }
        public double DS_Largo { get; set; }
        public double DS_Ancho { get; set; }
        public int IS_Cantidad { get; set; }
        public double DS_PrecioAprox { get; set; }
        public double DS_Descuento { get; set; }
        public double DS_ImporteTotal { get; set; }
        public string VS_Comentario { get; set; }
        public DateTime DTS_FechaEmicion { get; set; }
        public DateTime DTS_FechaRegistro { get; set; }
        public int IS_Ndias { get; set; }
        public DateTime DTS_FechaRecojo { get; set; }

        public int IS_EstadoPago { get; set; }

        public int FK_ISE_Cod { get; set; }

    }
}
