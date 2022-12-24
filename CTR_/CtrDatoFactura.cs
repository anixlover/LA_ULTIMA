using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    public class CtrDatoFactura
    {
        DaoDatoFactura objDaoDatoFactura;
        public CtrDatoFactura()
        {
            objDaoDatoFactura = new DaoDatoFactura();
        }
        public void RegistrarDatoFatcura(DtoDatoFactura objDtoDatoFactura)
        {
            objDaoDatoFactura.InsertDatoFatcura(objDtoDatoFactura);
        }
        public bool RUC_Duplicado(DtoDatoFactura objDtoDatoFactura)
        {
            return objDaoDatoFactura.SelectDatoFacturaxRUC_Dni(objDtoDatoFactura);
        }
        public DataTable ListarRucs(DtoDatoFactura objDtoDatoFactura)
        {
            return objDaoDatoFactura.SelectRUCxDNI(objDtoDatoFactura);
        }
        public void EliminarRUC(DtoDatoFactura objDtoDatoFactura)
        {
            objDaoDatoFactura.DeleteDatoFatcura(objDtoDatoFactura);
        }
        public bool formatoRUC(DtoDatoFactura objDtoDatoFactura)
        {
            string letras = "";
            bool correcto = true;
            string ruc = objDtoDatoFactura.VDF_Ruc;
            for (int i = 0; i < ruc.Trim().Length; i++)
            {
                correcto = char.IsDigit(ruc.Trim()[i]);
                if (!correcto)
                {
                    letras += ruc.Trim()[i];
                }
            }
            if (letras.Length > 0)
            {
                return false;
            }
            else
                return correcto;
        }
    }
}
