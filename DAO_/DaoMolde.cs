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
    public class DaoMolde
    {
        SqlConnection conexion;
        public DaoMolde()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarMolde(DtoMolde objDtoMolde)
        {
            SqlCommand command = new SqlCommand("Insert into T_MOLDE values (1,"+objDtoMolde.IML_Cantidad+","+objDtoMolde.FK_IM_Cod+")", conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectMoldexMoldura(DtoMolde objDtoMolde)
        {
            string select = "SELECT * FROM T_MOLDE WHERE FK_IM_Cod = '" + objDtoMolde.FK_IM_Cod + "'";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoMolde.PK_IM_Cod = (int)reader[0];
                objDtoMolde.IML_Cantidad = (int)reader[2];
            }
            conexion.Close();
            return hayRegistros;
        }
        public int SelectCantidadMoldexMoldura(DtoMolde objDtoMolde)
        {
            int cantidad;
            string select = "select IsNULL((SELECT IML_Cantidad FROM T_MOLDE where FK_IM_Cod =" + objDtoMolde.FK_IM_Cod + "),0)";
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            cantidad = (int)command.ExecuteScalar();
            conexion.Close();
            return cantidad;
        }
        public DataTable SelectMoldes()
        {
            DataTable dtmoldes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("select PK_IML_Cod,CASE WHEN VML_Disponibilidad=1 THEN 'Disponible' WHEN VML_Disponibilidad=0 THEN 'No disponible' END AS VML_Disponibilidad,IML_Cantidad,FK_IM_Cod from T_MOLDE", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtmoldes = new DataTable();
            daAdaptador.Fill(dtmoldes);
            conexion.Close();
            return dtmoldes;
        }
        public DataTable SelectMoldesxCodigoMoldura(DtoMolde objDtoMolde)
        {
            DataTable dtmoldes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("select PK_IML_Cod,CASE WHEN VML_Disponibilidad=1 THEN 'Disponible' WHEN VML_Disponibilidad=0 THEN 'No disponible' END AS VML_Disponibilidad,IML_Cantidad,FK_IM_Cod from T_MOLDE where FK_IM_Cod=" + objDtoMolde.FK_IM_Cod, conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            dtmoldes = new DataTable();
            daAdaptador.Fill(dtmoldes);
            conexion.Close();
            return dtmoldes;
        }
        public void UpdateCantidadMolduraResta(DtoMolde objDtoMolde)
        {
            SqlCommand command = new SqlCommand("update T_MOLDE set IML_Cantidad=((select IML_Cantidad from T_MOLDE where FK_IM_Cod=" + objDtoMolde.FK_IM_Cod+")-"+objDtoMolde.IML_Cantidad+") where FK_IM_Cod="+objDtoMolde.FK_IM_Cod, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void UpdateCantidadMolduraSuma(DtoMolde objDtoMolde)
        {
            SqlCommand command = new SqlCommand("update T_MOLDE set IML_Cantidad=((select IML_Cantidad from T_MOLDE where FK_IM_Cod=" + objDtoMolde.FK_IM_Cod + ")+" + objDtoMolde.IML_Cantidad + ") where FK_IM_Cod=" + objDtoMolde.FK_IM_Cod, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
