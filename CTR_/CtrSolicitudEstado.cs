using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace CTR
{
    public class CtrSolicitudEstado
    {
        DaoSolicitudEstado objDaoSolicitudEstado;
        public CtrSolicitudEstado()
        {
            objDaoSolicitudEstado = new DaoSolicitudEstado();
        }
        public DataSet ListarEstados()
        {
            return objDaoSolicitudEstado.SelectEstado();
        }
    }
}
