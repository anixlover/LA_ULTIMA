using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoSolicitudEstado
    {
        SqlConnection conexion;
        public DaoSolicitudEstado()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataSet SelectEstado()
        {
            SqlDataAdapter Estado = new SqlDataAdapter("SELECT*FROM T_SOLICITUD_ESTADO", conexion);
            DataSet DS = new DataSet();
            Estado.Fill(DS);
            return DS;
        }
    }
}
