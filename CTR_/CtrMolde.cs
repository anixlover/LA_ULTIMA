using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CtrMolde
    {
        DaoMolde objDaoMolde;
        public CtrMolde()
        {
            objDaoMolde = new DaoMolde();
        }
        public void RegistrarMolde(DtoMolde objDtoMolde)
        {
            objDaoMolde.InsertarMolde(objDtoMolde);
        }
        public bool ExistenciaMolde(DtoMolde objDtoMolde)
        {
            return objDaoMolde.SelectMoldexMoldura(objDtoMolde);
        }
        public DataTable ListarMoldes()
        {
            return objDaoMolde.SelectMoldes();
        }
        public DataTable ListarMoldesxCodigoMoldura(DtoMolde objDtoMolde)
        {
            return objDaoMolde.SelectMoldesxCodigoMoldura(objDtoMolde);
        }
        public int CantidadMoldesxMoldura(DtoMolde objDtoMolde)
        {
            return objDaoMolde.SelectCantidadMoldexMoldura(objDtoMolde);
        }
        public void Restarmoldes(DtoMolde objDtoMolde)
        {
            objDaoMolde.UpdateCantidadMolduraResta(objDtoMolde);
        }
        public void AumentarMoldes(DtoMolde objDtoMolde)
        {
            objDaoMolde.UpdateCantidadMolduraSuma(objDtoMolde);
        }
    }
}
