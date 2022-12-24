using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dto_Voucher
    {
        public string PK_VV_NumVoucher { get; set; }
        public byte[] VBV_Foto { get; set; }
        public double DV_ImporteDepositado { get; set; }
        public string VV_Comentario { get; set; }
        public string FK_VP_Cod { get; set; }
    }
}
