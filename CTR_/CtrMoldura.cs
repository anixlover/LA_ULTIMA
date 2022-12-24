using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrMoldura
    {
        DaoMoldura objDaoMoldura;
        public CtrMoldura()
        {
            objDaoMoldura = new DaoMoldura();
        }
        
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objDtoTipoMoldura)
        {
            return objDaoMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
        }
        public void registrarImgMoldura(byte[] arreglo, int id)
        {
            objDaoMoldura.RegistrarImgMoldura(arreglo, id);
        }
        public void registrarMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.InsertMoldura(objDtoMoldura);
        }
        public DataTable ListarTodoMoldura(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.ListarTodoMolduras(objDtoMoldura);
        }
        public void InsertMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.InsertMoldura(objDtoMoldura);
        }
        public DataTable RetornarImagenMoldura(int id)
        {
            return objDaoMoldura.SelectImagenMoldura(id);
        }
        public DataTable ListarMolduras()
        {
            return objDaoMoldura.ListarMolduras();
        }
        public void ObtenerMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            objDaoMoldura.ObtenerMoldura(objmoldura, objtipo);
        }
        public void ActulizarMoldura(DtoMoldura objMoldura)
        {
            objDaoMoldura.UpdateMoldura(objMoldura);
        }
        public int StockMoldura(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.StockMoldura(objDtoMoldura);
        }
       public DataTable DataMolduraxCodMoldura_y_Tipo(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.SelectMoldurasTipoCodMoldura(objDtoMoldura);
        }
        public DataTable DataMolduraxCodMoldura(DtoMoldura objDtoMoldura)
        {
            return objDaoMoldura.SelectMoldurasVista(objDtoMoldura);
        }
        public DataSet OpcionesTipoMoldura()
        {
            return objDaoMoldura.desplegableTipoMoldura();
        }
        public double PrecioAprox(DtoMoldura objMoldura)
        {
            return objDaoMoldura.PrecioAprox(objMoldura);
        }
        public DataTable ObtenerMoldura2(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            return objDaoMoldura.ObtenerMoldura2(objmoldura, objtipo);
        }
        public DataTable CalcularSubtotal(DtoMoldura objmoldura, DtoTipoMoldura objtipo, double cant)
        {
            return objDaoMoldura.CalcularSubtotal(objmoldura, objtipo, cant);
        }
        public void ActualizarStockxMoldura(DtoMoldura objmoldura)
        {
            objDaoMoldura.ActualizarStockxMoldura(objmoldura);
        }
        public bool MolduraExiste(DtoMoldura objmoldura)
        {
            return objDaoMoldura.SelectMolduraID(objmoldura);
        }
        public double Aprox(DtoMoldura objMoldura)
        {
            return objDaoMoldura.Aprox(objMoldura);
        }
        public int TraerStock(int idMoldura)
        {
            return objDaoMoldura.TraerStock(idMoldura);
        }
    }
}
