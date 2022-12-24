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
    public class DaoMolduraXUsuario
    {
        SqlConnection conexion;
        public DaoMolduraXUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListaMoldurasSolicitud(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud", conexion);
            command.Parameters.AddWithValue("@sol", objDtoMolduraXUsuario.FK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesxDNI(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_SolicitudesxDNI", conexion);
            command.Parameters.AddWithValue("@dni", objDtoMolduraXUsuario.FK_VU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesxDNI_y_Estado(DtoMolduraXUsuario objDtoMolduraXUsuario, int estado)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_SolicitudesxDNI_y_Estado", conexion);
            command.Parameters.AddWithValue("@dni", objDtoMolduraXUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idSolEst",estado);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public bool ExistenciaMXU(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "select * from T_MOLDURAXUSUARIO where FK_VU_Dni ='"+ objDtoMolduraXUsuario.FK_VU_Dni + "' and FK_IM_Cod = "+ objDtoMolduraXUsuario.FK_IM_Cod + " and FK_IMXUE_Cod =2" ;
            SqlCommand command = new SqlCommand(select,conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoMolduraXUsuario.PK_IMU_Cod = (int)reader[0];
                objDtoMolduraXUsuario.IMU_Cantidad = (int)reader[3];
                objDtoMolduraXUsuario.DMU_Precio= Convert.ToDouble(reader[4].ToString());
                objDtoMolduraXUsuario.FK_IM_Cod = (int)reader[2];
            }
            conexion.Close();
            return hayRegistros;

        }

        public int CantMolduras(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "select count(FK_IM_Cod) from T_MOLDURAXUSUARIO where FK_IS_Cod=" + objDtoMolduraXUsuario.FK_IS_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            int cant = 0;
            if (hayRegistros)
            {
                cant= (int)reader[0];                
            }
            conexion.Close();
            return cant;

        }
        public int CantMoldurasDespachadas(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "select count(FK_IM_Cod) from T_MOLDURAXUSUARIO where FK_IS_Cod="+ objDtoMolduraXUsuario.FK_IS_Cod+" and FK_IMXUE_Cod =11";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            int cant = 0;
            if (hayRegistros)
            {
                cant = (int)reader[0];
            }
            conexion.Close();
            return cant;

        }
        public bool ExistenciaMXU2(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "SELECT [PK_IMU_Cod],[FK_VU_Dni],[FK_IM_Cod],[IMU_Cantidad],Isnull([DMU_Precio],0),[FK_IS_Cod],[FK_IMXUE_Cod],[IMU_MoldesUsados] from T_MOLDURAXUSUARIO where FK_IM_Cod = " + objDtoMolduraXUsuario.FK_IM_Cod + " and FK_IS_Cod =" + objDtoMolduraXUsuario.FK_IS_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoMolduraXUsuario.PK_IMU_Cod = (int)reader[0];
                objDtoMolduraXUsuario.FK_VU_Dni = (string)reader[1];
                objDtoMolduraXUsuario.IMU_Cantidad = (int)reader[3];
                objDtoMolduraXUsuario.DMU_Precio = Convert.ToDouble(reader[4].ToString());
                objDtoMolduraXUsuario.FK_IM_Cod = (int)reader[2];
            }
            conexion.Close();
            return hayRegistros;
        }
        public void UpdateMXU_x_codigo(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "Update T_MOLDURAXUSUARIO set [FK_IMXUE_Cod] ="+objDtoMolduraXUsuario.FK_IMXUE_Cod+ " where PK_IMU_Cod="+objDtoMolduraXUsuario.PK_IMU_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateCantMoldesMXU_x_codigo(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "Update T_MOLDURAXUSUARIO set [IMU_MoldesUsados] =" + objDtoMolduraXUsuario.IMU_MoldesUsados + " where FK_IS_Cod=" + objDtoMolduraXUsuario.FK_IS_Cod+ " and FK_IM_Cod=" + objDtoMolduraXUsuario.FK_IM_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateCantMoldesCeroMXU_x_codigo(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "Update T_MOLDURAXUSUARIO set [IMU_MoldesUsados] =0 where FK_IS_Cod=" + objDtoMolduraXUsuario.FK_IS_Cod + " and FK_IM_Cod=" + objDtoMolduraXUsuario.FK_IM_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateMXU_x_codigoSOL(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "Update T_MOLDURAXUSUARIO set [FK_IMXUE_Cod] =6 where FK_IS_Cod=" + objDtoMolduraXUsuario.FK_IS_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool ExistenciaMXU_x_Cod(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            string select = "select PK_IMU_Cod,FK_VU_Dni,FK_IM_Cod,IMU_Cantidad,Isnull(DMU_Precio,0),FK_IS_Cod,FK_IMXUE_Cod,isnull(IMU_MoldesUsados, 0) as IMU_MoldesUsados from T_MOLDURAXUSUARIO where PK_IMU_Cod="+objDtoMolduraXUsuario.PK_IMU_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoMolduraXUsuario.PK_IMU_Cod = (int)reader[0];
                objDtoMolduraXUsuario.IMU_Cantidad = (int)reader[3];
                objDtoMolduraXUsuario.DMU_Precio = Convert.ToDouble(reader[4].ToString());
                objDtoMolduraXUsuario.FK_IM_Cod = (int)reader[2];
                objDtoMolduraXUsuario.FK_IMXUE_Cod = (int)reader[6];
                objDtoMolduraXUsuario.IMU_MoldesUsados = (int)reader[7];
            }
            conexion.Close();
            return hayRegistros;

        }
        public void InsertarMolduraxUsuario(DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDni", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idCodM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void actulizarExistenciaMXU  (DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarExistenciaMXU", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idDni", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idCodM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cantidad", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@precio", objMolduraxUsuario.DMU_Precio);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ListarMXU(DtoMolduraXUsuario objmxu)
        {
            DataTable dtmxu = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_MXU_C", conexion);
            command.Parameters.AddWithValue("@idU", objmxu.FK_VU_Dni);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmxu = new DataTable();
            daAdaptador.Fill(dtmxu);
            conexion.Close();
            return dtmxu;
        }
        public void eliminarMXU(DtoMolduraXUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_Eliminar_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.FK_IM_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ObtenerMXU(DtoMoldura objmoldura, DtoMolduraXUsuario objmxu, DtoTipoMoldura tm)
        {
            SqlCommand command = new SqlCommand("SP_Detalle_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", objmxu.PK_IMU_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmxu.PK_IMU_Cod = Convert.ToInt32(reader[0].ToString());
                objmoldura.PK_IM_Cod = Convert.ToInt32(reader[1].ToString());
                tm.PK_ITM_Tipo = Convert.ToInt32(reader[2].ToString());
                objmoldura.VM_Descripcion = reader[3].ToString();

                tm.VTM_Nombre = reader[4].ToString();
                objmoldura.DM_Largo = Convert.ToDouble(reader[5].ToString());
                objmoldura.DM_Ancho = Convert.ToDouble(reader[6].ToString());
                tm.VTM_UnidadMetrica = reader[7].ToString();
                objmxu.IMU_Cantidad = Convert.ToInt32(reader[8].ToString());
                objmxu.DMU_Precio = Convert.ToDouble(reader[9].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[10].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }
        public void actualizarMXU(DtoMolduraXUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarCant_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@cant", objmxu.IMU_Cantidad);
            command.Parameters.AddWithValue("@precio", objmxu.DMU_Precio);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void actualizarMXUSol(DtoMolduraXUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarSol_MXU_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@sol", objmxu.FK_IS_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertarMolduraxUsuariox2(DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_C_3", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);
            command.Parameters.Add("@newId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@newId"].Value);
            }
            conexion.Close();
        }
        public void registrarMXU(DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_P", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@idM", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@pre", objMolduraxUsuario.DMU_Precio);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void registrarMXUP(DtoMolduraXUsuario objMolduraxUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_MXU_PP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idU", objMolduraxUsuario.FK_VU_Dni);
            command.Parameters.AddWithValue("@cant", objMolduraxUsuario.IMU_Cantidad);
            command.Parameters.AddWithValue("@codMoldura", objMolduraxUsuario.FK_IM_Cod);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objMolduraxUsuario.PK_IMU_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        public void actualizarMXUSolP(DtoMolduraXUsuario objmxu)
        {
            SqlCommand command = new SqlCommand("SP_ActualizarSol_MXU_P", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objmxu.PK_IMU_Cod);
            command.Parameters.AddWithValue("@sol", objmxu.FK_IS_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
