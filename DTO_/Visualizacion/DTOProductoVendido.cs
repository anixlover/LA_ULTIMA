using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Visualizacion
{
    public class DTOProductoVendido
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }

    }
}
