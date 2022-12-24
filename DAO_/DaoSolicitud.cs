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
    public class DaoSolicitud
    {
        SqlConnection conexion;
        public DaoSolicitud()
        {
            conexion= new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool SelectSolicitudTipo(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.PK_IS_Cod = (int)reader[0];
                objsol.VS_TipoSolicitud = (string)reader[1];
                objsol.FK_ISE_Cod = (int)reader[15];
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectSolicitudFechaRegistro(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.PK_IS_Cod = (int)reader[0];
                objsol.VS_TipoSolicitud = (string)reader[1];
                objsol.FK_ISE_Cod = (int)reader[15];
                objsol.DTS_FechaRegistro = Convert.ToDateTime(reader[11].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectSolicitudImporte(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.PK_IS_Cod = (int)reader[0];
                objsol.DS_ImporteTotal = Convert.ToDouble(reader[8].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectSolicitudDiseñoPersonalizado(DtoSolicitud objsol)
        {
            string Select = "SELECT  [PK_IS_Cod],[VS_TipoSolicitud],[VBS_Imagen],[DS_Largo],[DS_Ancho],[IS_Cantidad],[DS_PrecioAprox],[DS_Descuento], Isnull([DS_ImporteTotal],0),[VS_Comentario],[DTS_FechaEmicion],[DTS_FechaRegistro],[IS_Ndias],[DTS_FechaRecojo],[IS_EstadoPago],[FK_ISE_Cod] from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.VS_TipoSolicitud = (string)reader[1];
                objsol.DS_PrecioAprox = Convert.ToDouble(reader[6].ToString());
                objsol.DS_ImporteTotal = Convert.ToDouble(reader[8].ToString());
                //objsol.VBS_Imagen = (byte[])reader[2];
                //objsol.VS_Comentario = (string)reader[9];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataTable SelectSolicitudesTrabajador()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("select * from Vista_Solicitudes_Trabajador", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesTerminadasBetween(string fechaInicio,string fechaFin)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SELECT* FROM Vista_Solicitudes_Entregados where DTS_FechaRecojo BETWEEN '"+ fechaInicio+"' and '"+fechaFin+"'", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesTerminadas()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SELECT* FROM Vista_Solicitudes_Entregados", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudDiseñoPropioIMG(DtoSolicitud objsol)
        {
            DataTable dtsolicitudes = null;
            string select = "SELECT VBS_Imagen from T_Solicitud where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand command = new SqlCommand(select, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudDiseñoPropio(DtoSolicitud objsol)
        {
            DataTable dtsolicitudes = null;
            string select = "SELECT PK_IMU_Cod,PK_IS_Cod,DS_Largo,DS_Ancho,VS_Comentario,IS_Cantidad,DS_PrecioAprox,DTS_FechaRecojo,DS_ImporteTotal,FK_IMXUE_Cod from Vista_Solicitud_Personalizado where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand command = new SqlCommand(select, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public void UpdateEstadoSolicitud_RevisióPago(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 6, DTS_FechaEmicion= GETDATE()  Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Rechazado(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 4 Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Observacion(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 7, VS_Comentario='"+objsolicitud.VS_Comentario+"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Despachado(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 12 Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateEstadoSolicitud_Pendiente_pago(DtoSolicitud objsolicitud)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 5 Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            //string update = "UPDATE T_Solicitud SET FK_ISE_Cod = 6, DTS_FechaEmicion='"+ DateTime.Today.Date +"' Where PK_IS_Cod=" + objsolicitud.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable SelectSolicitudes()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Administrar_Solicitudes", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable SelectSolicitudesDiseñoPropio_Clientes()
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Solicitudes_DiseñoPropio", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataSet desplegableSolicitudEstado()
        {
            string Select = "SELECT * from T_Solicitud_Estado";
            SqlCommand command = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            DataSet DS = new DataSet();
            daAdaptador.Fill(DS);
            return DS;
        }
        public DataTable SelectSolicitudes(string tipo)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Administrar_Solicitudes_Filtro", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@tipo", tipo);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public string SelectSolicitudPago(DtoSolicitud objsol)
        {
            string v = "";
            SqlCommand unComando = new SqlCommand("SP_SelectPagos", conexion);
            conexion.Open();
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@sol", objsol.PK_IS_Cod);
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                v = (string)reader[0];
            }
            conexion.Close();
            return v;
        }
        public bool SelectSolicitud(DtoSolicitud objsol)
        {
            string Select = "SELECT * from T_SOLICITUD where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objsol.VS_TipoSolicitud = (string)reader[1];
            }
            conexion.Close();
            return hayRegistros;
        }
        public DataTable ListaMoldurasSolicitud(DtoSolicitud objSol)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud", conexion);
            command.Parameters.AddWithValue("@sol", objSol.PK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public DataTable ListaMoldurasSolicitudXDiseñoPropio(DtoSolicitud objSol)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras_Solicitud_Diseño_Propio", conexion);
            command.Parameters.AddWithValue("@sol", objSol.PK_IS_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
        public void Actualizar_Estado_SolicitudX1(DtoSolicitud objsol)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 8, DTS_FechaRegistro=GETDATE(), DTS_FechaRecojo=DATEADD(day,15,GETDATE()) where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand unComando = new SqlCommand(update, conexion);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Actualizar_Estado_SolicitudX1PDP(DtoSolicitud objsol)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 8, DTS_FechaRegistro=GETDATE() where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand unComando = new SqlCommand(update, conexion);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Actualizar_Estado_SolicitudX2(DtoSolicitud objsol)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 5 where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand unComando = new SqlCommand(update, conexion);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Update_Estado_SolicitudEnProceso(DtoSolicitud objsol)
        {
            string update = "UPDATE T_SOLICITUD SET FK_ISE_Cod = 9 where PK_IS_Cod =" + objsol.PK_IS_Cod;
            conexion.Open();
            SqlCommand unComando = new SqlCommand(update, conexion);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_C", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void UpdateSolicitudFecha_RevisionFecha(DtoSolicitud objsol)
        {
            string update = "UPDATE T_Solicitud SET DTS_FechaRecojo=CAST(DATEADD(day," + objsol.IS_Ndias + ",GETDATE()) AS DATE),FK_ISE_Cod=3, DS_ImporteTotal="+objsol.DS_ImporteTotal+", IS_Ndias="+objsol.IS_Ndias+" where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateSolicitudFecha_Terminado(DtoSolicitud objsol)
        {
            string update = "UPDATE T_Solicitud SET FK_ISE_Cod=11 where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateSolicitudFecha(DtoSolicitud objsol)
        {
            string update = "UPDATE T_Solicitud SET DTS_FechaRecojo=CAST(DATEADD(day," + objsol.IS_Ndias + ",(select DTS_FechaRegistro from T_SOLICITUD where PK_IS_Cod ="+objsol.PK_IS_Cod+")) AS DATE),IS_Ndias=" + objsol.IS_Ndias + " where PK_IS_Cod =" + objsol.PK_IS_Cod;
            SqlCommand unComando = new SqlCommand(update, conexion);
            conexion.Open();
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public int SelectSolicitudMoldes(DtoSolicitud objsol)
        {
            int cantMoldurasconMolde;
            string Select = "select count(*) as cantidadMolduras from Vista_Moldes_Solicitud where FK_IS_Cod="+objsol.PK_IS_Cod+" and IML_Cantidad>0";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            cantMoldurasconMolde = (int)unComando.ExecuteScalar();
            conexion.Close();
            return cantMoldurasconMolde;
        }
        public void RegistrarSolicitud_PxPD(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_PxDP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoSol", objsolicitud.VS_TipoSolicitud);
            var binary1 = command.Parameters.Add("@img", SqlDbType.VarBinary, -1);
            binary1.Value = DBNull.Value;

            //var binary1 = command.Parameters.Add("@img", SqlDbType.VarBinary, -1);
            //binary1.Value = DBNull.Value;
            command.Parameters.AddWithValue("@largo", objsolicitud.DS_Largo);
            command.Parameters.AddWithValue("@ancho", objsolicitud.DS_Ancho);
            command.Parameters.AddWithValue("@cant", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@precioaprox", objsolicitud.DS_PrecioAprox);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void RegistrarSolicitud_PxC(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_PxC", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoSol", objsolicitud.VS_TipoSolicitud);
            command.Parameters.AddWithValue("@cant", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.AddWithValue("@fechareco", objsolicitud.DTS_FechaRecojo);
            command.Parameters.Add("@newID", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@newID"].Value);
            }
            conexion.Close();
        }
        public void RegistrarSolicitud_PExC(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_PExC", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoSol", objsolicitud.VS_TipoSolicitud);
            //command.Parameters.AddWithValue("@cant", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.AddWithValue("@fechareco", objsolicitud.DTS_FechaRecojo);
            //command.Parameters.Add("@newID", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarSolicitud_LD2(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolicitud_C_2", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.AddWithValue("@cantidad", objsolicitud.IS_Cantidad);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public double SelectImporteTotalSolicitudes()
        {
            double total=0;
            string Select = "SELECT Isnull((Select SUM(DS_ImporteTotal) As ImporteTotal FROM Vista_Solicitudes_Entregados),0)";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                total = double.Parse(reader[0].ToString());
            }
            conexion.Close();
            return total;
        }
        public int SelectDiasSolicitudes(DtoSolicitud objDtoSolicitud)
        {
            int dias = 0;
            string Select = "SELECT ISNULL((select IS_Ndias from T_SOLICITUD where PK_IS_Cod="+ objDtoSolicitud.PK_IS_Cod+ "),0)";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                dias = int.Parse(reader[0].ToString());
            }
            conexion.Close();
            return dias;
        }
        public double SelectImporteTotalSolicitudesEntreFechas(string fechaInicio, string fechaFin)
        {
            double total = 0;
            string Select = "select Isnull((SELECT SUM(DS_ImporteTotal) As ImporteTotal FROM Vista_Solicitudes_Entregados where DTS_FechaRecojo BETWEEN '" + fechaInicio + "' and '" + fechaFin + "'),0)";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                total = double.Parse(reader[0].ToString());
            }
            conexion.Close();
            return total;
        }

        public void RegistrarSolcitud_PC(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolcitud_PC", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tipos", objsolicitud.VS_TipoSolicitud);
            command.Parameters.AddWithValue("@cantidad", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@desc", objsolicitud.DS_Descuento); command.Parameters.AddWithValue("@impt", objsolicitud.DS_ImporteTotal);
            command.Parameters.AddWithValue("@comen", objsolicitud.VS_Comentario);
            command.Parameters.AddWithValue("@epago", objsolicitud.IS_EstadoPago);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }

        public void RegistrarImgSolicitud(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Imagen_Solicitud_Personalizado_Diseño_Propio", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idSol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void RegistrarSolicitud_PP(DtoSolicitud objsolicitud)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarSolcitud_PP", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tipos", objsolicitud.VS_TipoSolicitud);
            command.Parameters.AddWithValue("@largo", objsolicitud.DS_Largo);
            command.Parameters.AddWithValue("@ancho", objsolicitud.DS_Ancho);
            command.Parameters.AddWithValue("@cantidad", objsolicitud.IS_Cantidad);
            command.Parameters.AddWithValue("@aprox", objsolicitud.DS_PrecioAprox);
            command.Parameters.AddWithValue("@comen", objsolicitud.VS_Comentario);
            command.Parameters.AddWithValue("@epago", objsolicitud.IS_EstadoPago);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objsolicitud.PK_IS_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public DataTable SelectIncidentesxSolicitud(DtoSolicitud objsolicitud)
        {
            DataTable dtsolicitudes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("Select * from Vista_Incidentes where FK_IS_Cod="+objsolicitud.PK_IS_Cod, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtsolicitudes = new DataTable();
            daAdaptador.Fill(dtsolicitudes);
            conexion.Close();
            return dtsolicitudes;
        }
    }
}
