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
    public class CtrMXUEstado
    {
        DaoMXUEstado objDaoMXUEstado;
        public CtrMXUEstado()
        {
            objDaoMXUEstado = new DaoMXUEstado();
        }
        public DataSet ListarEstados()
        {
            return objDaoMXUEstado.SelectMXUEstado();
        }
    }
}
