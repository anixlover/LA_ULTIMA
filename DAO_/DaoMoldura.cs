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
    public class DaoMoldura
    {
        SqlConnection conexion;
        public DaoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public DataTable ListarMoldurasPaginaInicial(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras=null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Detalles_Moldura_by_TipoMoldura", conexion);
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public void RegistrarImgMoldura(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Imagen_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@largo", objmoldura.DM_Largo);
            command.Parameters.AddWithValue("@ancho", objmoldura.DM_Ancho);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objmoldura.PK_IM_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void UpdateMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@largo", objmoldura.DM_Largo);
            command.Parameters.AddWithValue("@ancho", objmoldura.DM_Ancho);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ListarTodoMolduras(DtoMoldura objmoldura)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Todo_Moldura", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }

        public void ActualizarImgMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Imagen_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@imagen", objmoldura.VBM_Imagen);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ListarMolduras()
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public DataTable SelectImagenMoldura(int id)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Obtener_Imagen_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }

        public void ObtenerMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objtipo.PK_ITM_Tipo = int.Parse(reader[2].ToString());
                objtipo.VTM_Nombre = reader[3].ToString();
                objmoldura.DM_Largo = Convert.ToDouble(reader[4].ToString());
                objmoldura.DM_Ancho = Convert.ToDouble(reader[5].ToString());
                objtipo.VTM_UnidadMetrica = reader[6].ToString();
                objmoldura.IM_Estado = int.Parse(reader[7].ToString());
                objmoldura.IM_Stock = int.Parse(reader[8].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[9].ToString());
                objmoldura.VBM_Imagen = (byte[])reader[10];
            }
            conexion.Close();
        }
        public int StockMoldura(DtoMoldura objMoldura)
        {
            try
            {
                string select = "SELECT IM_Stock FROM T_MOLDURA WHERE PK_IM_Cod=" + objMoldura.PK_IM_Cod;
                int valor_retornado = 0;
                SqlCommand command = new SqlCommand(select, conexion);
                conexion.Open();
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    valor_retornado = int.Parse(reader[0].ToString());
                }
                conexion.Close();
                return valor_retornado;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet desplegableTipoMoldura()
        {
            string select = "SELECT * FROM T_TIPO_MOLDURA";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataAdapter daAdapter = new SqlDataAdapter(command);
            DataSet DS = new DataSet();
            daAdapter.Fill(DS);
            return DS;
        }
        public double PrecioAprox(DtoMoldura objMoldura)
        {           
            SqlCommand cmd = new SqlCommand("select sum(DM_Precio)/ COUNT(*) as promedio from T_Moldura where FK_ITM_Tipo= " + objMoldura.FK_ITM_Tipo, conexion);
            Console.WriteLine(cmd);
            conexion.Open();
            string aprox = cmd.ExecuteScalar().ToString();
            conexion.Close();
            if (aprox == "")
            {
                return 0;
            }
            return Convert.ToDouble(aprox);
        }
        public DataTable ObtenerMoldura2(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            DataTable dt = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura2", conexion);
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            daAdaptador.Fill(dt);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader["PK_IM_Cod"].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader["VBM_Imagen"].ToString());
                objtipo.VTM_Nombre = reader["VTM_Nombre"].ToString();
                objmoldura.DM_Largo = Double.Parse(reader["DM_Largo"].ToString());
                objmoldura.DM_Ancho = Double.Parse(reader["DM_Ancho"].ToString());
                objmoldura.IM_Stock = int.Parse(reader["IM_Stock"].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader["DM_Precio"].ToString());
            }
            conexion.Close();
            return dt;
        }
        public DataTable CalcularSubtotal(DtoMoldura objmoldura, DtoTipoMoldura objtipo, double cant)
        {
            DataTable dt = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_CalcularSubtotal", conexion);
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@cantidad", cant);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            daAdaptador.Fill(dt);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader["PK_IM_Cod"].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader["VBM_Imagen"].ToString());
                objtipo.VTM_Nombre = reader["VTM_Nombre"].ToString();
                objmoldura.DM_Largo = Double.Parse(reader["DM_Largo"].ToString());
                objmoldura.DM_Ancho = Double.Parse(reader["DM_Ancho"].ToString());
                objmoldura.IM_Stock = int.Parse(reader["IM_Stock"].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader["DM_Precio"].ToString());
                //objmoldura.DM_subtotal = Double.Parse(reader["Subtotal"].ToString());
            }
            conexion.Close();
            return dt;
        }
        public void ActualizarStockxMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Stock_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectMolduraID(DtoMoldura objmoldura)
        {
            string Select = "SELECT * from T_Moldura where PK_IM_Cod =" + objmoldura.PK_IM_Cod;

            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[2].ToString());
                objmoldura.IM_Stock = int.Parse(reader[3].ToString());
                objmoldura.DM_Largo = Convert.ToDouble(reader[4].ToString());
                objmoldura.DM_Ancho = Convert.ToDouble(reader[5].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[6].ToString());
            }
            conexion.Close();
            return hayRegistros;
        }

        public DataTable SelectMoldurasTipoCodMoldura(DtoMoldura objMoldura)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("Select * from Vista_Molduras_consulta where Codigo="+objMoldura.PK_IM_Cod+ " and PK_ITM_Tipo="+objMoldura.FK_ITM_Tipo, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public DataTable SelectMoldurasVista(DtoMoldura objMoldura)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("Select * from Vista_Molduras_consulta where Codigo=" + objMoldura.PK_IM_Cod, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public double Aprox(DtoMoldura objMoldura)
        {
            //SqlConnection con = new SqlConnection(@"data source=DESKTOP-4LVLNRM; initial catalog=BD_SCPEDR; integrated security=SSPI;");
            //double aprox = 0;
            SqlCommand cmd = new SqlCommand("select sum(DM_Precio)/ COUNT(*) as promedio from T_MOLDURA where FK_ITM_Tipo = " + objMoldura.FK_ITM_Tipo, conexion);
            Console.WriteLine(cmd);
            conexion.Open();
            string aprox = cmd.ExecuteScalar().ToString();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    aprox = double.Parse(reader[0].ToString());

            //}
            conexion.Close();
            if (aprox == "")
            {
                return 0;
            }
            //return aprox;
            return Convert.ToDouble(aprox);
            /** 
             * SqlCommand unComando = new SqlCommand("select DS_ImporteTotal from T_Solicitud where PK_IS_Cod =" + objsolicitud.FK_IS_Cod, conexion);
            conexion.Open();
            var ultimo = unComando.ExecuteScalar().ToString();
            conexion.Close();
            return Convert.ToDouble(ultimo);**/
        }
        public int TraerStock(int idMoldura)
        {
            SqlCommand command = new SqlCommand("SP_TraerStock", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idCodM", idMoldura);
            conexion.Open();
            var stock = -1;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                stock = int.Parse(reader["IM_Stock"].ToString());
            }
            conexion.Close();
            return stock;
        }
    }
}
