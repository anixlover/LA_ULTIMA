using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DtoMoldura
    {
        public int PK_IM_Cod { get; set; }
        public string VM_Descripcion { get; set; }
        public byte[] VBM_Imagen { get; set; }
        public int IM_Stock { get; set; }
        public double DM_Largo { get; set; }
        public double DM_Ancho { get; set; }
        public double DM_Precio { get; set; }
        public int IM_Estado { get; set; }
        public int FK_ITM_Tipo { get; set; }
        public double DM_Subtotal { get; set; }
    }
}
