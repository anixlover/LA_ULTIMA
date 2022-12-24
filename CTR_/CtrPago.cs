using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrPago
    {
        DaoPago objDaoPago;
        public CtrPago()
        {
            objDaoPago = new DaoPago();
        }
        public void RegistrarPago(DtoPago objDtoPago)
        {
            objDaoPago.InsertarPago(objDtoPago);
        }
        public void RegistrarPagoB(DtoPago objDtoPago)
        {
            objDaoPago.InsertarPagoB(objDtoPago);
        }
        public bool ExistenciaPago(DtoPago objDtoPago)
        {
            return objDaoPago.SelectPagoxCod_Solicitud(objDtoPago);
        }
        public bool HayRUC(DtoPago p)
        {
            return objDaoPago.SelectPagoRUC(p);
        }
        public void AgregarRestante(DtoPago objpago)
        {
            objDaoPago.UpdatePago_restante(objpago);
        }
    }
}
