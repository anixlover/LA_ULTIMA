using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO
{
    public class DtoComprando
    {
        public string PK_VC_Cod { get; set; }
        public DateTime DTC_FechaEmision { get; set; }
        public string VC_Moneda { get; set; }
        public string VC_LugarEntrega { get; set; }
        public double DC_SubtotalVenta { get; set; }
        public double DC_Anticipo { get; set; }
        public double DC_VentaProforma { get; set; }
        public double DC_Igv { get; set; }
        public double DC_ImporteTotal { get; set; }
        public string FK_VP_Cod { get; set; }
        public string FK_VTC_Cod { get; set; }

    }
}
