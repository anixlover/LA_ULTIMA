using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrMXU_Incidente
    {
        DaoMXU_Incidente objDaoMXUincidente;
        public CtrMXU_Incidente()
        {
            objDaoMXUincidente = new DaoMXU_Incidente();
        }
        public void RegistrarIncidente(DtoMxUIncidente objDtoMXUIncidente)
        {
            objDaoMXUincidente.InsertMXUIncidente(objDtoMXUIncidente);
        }
    }
}
