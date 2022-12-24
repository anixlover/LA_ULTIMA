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
    }
}
