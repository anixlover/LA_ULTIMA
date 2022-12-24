using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoTipoMoldura
    {
        SqlConnection conexion;
        public DaoTipoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void DetallesMolduraByTipoMoldura(DtoTipoMoldura objtipo, DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Detalles_Moldura_by_TipoMoldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter tipomoldura = new SqlDataAdapter(command);
            tipomoldura.Fill(ds);
            tipomoldura.Dispose();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[0].ToString());
   
                //objmoldura.DM_Medida = Convert.ToDouble(reader[1].ToString());
                objtipo.VTM_UnidadMetrica = reader[2].ToString();
                objmoldura.DM_Precio = Convert.ToDouble(reader[3].ToString());
                objmoldura.VM_Descripcion = reader[4].ToString();
            }
            conexion.Close();
            conexion.Dispose();
        }
        public void DetallesTipoMoldura(DtoTipoMoldura objtipo)
        {
            string select = "SELECT*FROM T_Tipo_Moldura where PK_ITM_Tipo=" + objtipo.PK_ITM_Tipo;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                objtipo.VTM_UnidadMetrica = (string)reader[2];
            }
            conexion.Close();
        }
        public void InspeccionarMolduraByTipoMoldura(DtoTipoMoldura objtipo, DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Inspeccionar_Moldura_by_TipoMoldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter tipomoldura = new SqlDataAdapter(command);
            tipomoldura.Fill(ds);
            tipomoldura.Dispose();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[0].ToString());
                //objmoldura.DM_Medida = Convert.ToDouble(reader[1].ToString());
                objtipo.VTM_UnidadMetrica = reader[2].ToString();
                objmoldura.DM_Precio = Convert.ToDouble(reader[3].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }
        public DataSet SelectTipoMoldura()
        {
            SqlDataAdapter tipomol = new SqlDataAdapter("select * from T_TIPO_MOLDURA", conexion);
            DataSet DS = new DataSet();
            tipomol.Fill(DS);
            return DS;
        }
        public DataTable SelectMoldurasxTipo(DtoTipoMoldura objDtoTipoMoldura)
        {
            DataTable dtmolduras;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_MoldurasxTipo", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@tipo", objDtoTipoMoldura.VTM_Nombre);
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
    }
}
