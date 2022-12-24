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
    public class DaoMXU_Incidente
    {
        SqlConnection conexion;
        public DaoMXU_Incidente()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertMXUIncidente(DtoMxUIncidente objDtoMxuIncidente)
        {
            string insert = "Insert into T_MXU_INCIDENTE values(GETDATE(),'" + objDtoMxuIncidente.VMXU_Incidente + "','"+objDtoMxuIncidente.FK_VMU_Dni+"',"+objDtoMxuIncidente.FK_IMU_Cod+")";
            SqlCommand command = new SqlCommand(insert, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }        
    }
}
