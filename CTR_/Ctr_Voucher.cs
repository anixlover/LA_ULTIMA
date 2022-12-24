using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class Ctr_Voucher
    {
        Dao_Voucher objDaoVoucher;
        public Ctr_Voucher()
        {
            objDaoVoucher = new Dao_Voucher();
        }
        public void RegistrarVoucher(Dto_Voucher objDtoVoucher)
        {
            objDaoVoucher.InsertarVoucher(objDtoVoucher);
        }
        public bool hayVoucher(Dto_Voucher voucher)
        {
            return objDaoVoucher.SelectPagoVoucher(voucher);
        }
        public bool ExistenciaVoucherxCodPago(Dto_Voucher voucher)
        {
            return objDaoVoucher.SelectImgVoucherxCodPago(voucher);
        }
    }
}
