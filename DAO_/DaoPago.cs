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
    public class DaoPago
    {
        SqlConnection conexion;
        public DaoPago()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void InsertarPago(DtoPago objpago)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarPago", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo", objpago.IP_TipoPago);
            cmd.Parameters.AddWithValue("@pagado", objpago.DP_ImportePagado);
            cmd.Parameters.AddWithValue("@restante", objpago.DP_ImporteRestante);
            cmd.Parameters.AddWithValue("@tipocertificado", objpago.IP_TipoCertificado);
            cmd.Parameters.AddWithValue("@ruc", objpago.VP_RUC);
            cmd.Parameters.AddWithValue("@solicitud", objpago.FK_IS_Cod);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void InsertarPagoB(DtoPago objpago)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarPago", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo", objpago.IP_TipoPago);
            cmd.Parameters.AddWithValue("@pagado", objpago.DP_ImportePagado);
            cmd.Parameters.AddWithValue("@restante", objpago.DP_ImporteRestante);
            cmd.Parameters.AddWithValue("@tipocertificado", objpago.IP_TipoCertificado);
            cmd.Parameters.AddWithValue("@ruc", objpago.VP_RUC);
            cmd.Parameters.AddWithValue("@solicitud", objpago.FK_IS_Cod);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void UpdatePago_restante(DtoPago objpago)
        {
            SqlCommand cmd = new SqlCommand("Update T_PAGO set DP_ImportePagado="+(objpago.DP_ImportePagado+objpago.DP_ImporteRestante)+", DP_ImporteRestante=0.00, IP_TipoPago=2 where FK_IS_Cod="+objpago.FK_IS_Cod, conexion);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public bool SelectPagoxCod_Solicitud(DtoPago objDtoPago)
        {
            string select = "SELECT * FROM T_PAGO WHERE FK_IS_Cod ="+ objDtoPago.FK_IS_Cod;
            SqlCommand command = new SqlCommand(select, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                objDtoPago.PK_VP_Cod = (string)reader[0];
                objDtoPago.IP_TipoPago = (int)reader[2];
                objDtoPago.DP_ImportePagado = double.Parse(reader[3].ToString());
                objDtoPago.DP_ImporteRestante = double.Parse(reader[4].ToString());
                objDtoPago.IP_TipoCertificado = (int)reader[5];
                objDtoPago.VP_RUC = (string)reader[6];
            }
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectPagoRUC(DtoPago p)
        {
            string Select = "SELECT * from T_Pago where FK_IS_Cod ='" + p.FK_IS_Cod + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                p.VP_RUC = (string)reader[6];
            }
            conexion.Close();
            return hayRegistros;
        }
    }
}
