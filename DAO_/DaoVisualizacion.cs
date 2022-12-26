using DAO;
using DTO;
using DTO.Visualizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_
{
    public class DaoVisualizacion
    {
        SqlConnection conexion;

        public DaoVisualizacion()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void GuardarVisualizacionUsuario(DtoVisualizacion dtoVisualizacion)
        {
            SqlCommand command = new SqlCommand("SP_Guardar_Visualizacion_Usuario", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            PrepararDatosParaGuardadoVisualizacion(command, dtoVisualizacion);

            conexion.Open();

            int totalRegistros = command.ExecuteNonQuery();

            if (totalRegistros == 0) throw new Exception($"No se pudo guardar el registro de visualización del usuario con IP { dtoVisualizacion.VS_Maquina }");

            conexion.Close();

        } 

        public List<DTOProductoVendido> ObtenerProductosVendidos()
        {
            var productosVendidos = new List<DTOProductoVendido>();

            SqlCommand command = new SqlCommand("SP_Obtener_Productos_Vendidos", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            conexion.Open();

            var dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    var productoVendido = new DTOProductoVendido();

                    productoVendido.Codigo = Convert.ToInt32(dataReader[0]);
                    productoVendido.Descripcion = Convert.ToString(dataReader[1]);
                    productoVendido.Precio = Convert.ToDouble(dataReader[2]);
                    productoVendido.Cantidad = Convert.ToInt32(dataReader[3]);
                    productoVendido.Monto = Convert.ToDouble(dataReader[4]);

                    productosVendidos.Add(productoVendido);

                }
            }

            conexion.Close();

            return productosVendidos;
        }

        public DTOVentaCatalogoDashboard ObtenerVentasCatalogo()
        {
            var ventaCatalogoDashboard = new DTOVentaCatalogoDashboard();

            SqlCommand command = new SqlCommand("SP_Obtener_Ventas_Catalogo", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            conexion.Open();

            var dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    ventaCatalogoDashboard.TotalVentasCatalogo = Convert.ToInt32(dataReader[0]);
                    ventaCatalogoDashboard.TotalVentasCatalogoMensual = Convert.ToInt32(dataReader[1]);
                }
            }

            conexion.Close();

            return ventaCatalogoDashboard;

        }

        public DTOVentaPersonalizadaDashboard ObtenerVentasPersonalizadas()
        {
            var ventaPersonalizadaDashboard = new DTOVentaPersonalizadaDashboard();
            
            SqlCommand command = new SqlCommand("SP_Obtener_Ventas_Personalizado", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            conexion.Open();

            var dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    ventaPersonalizadaDashboard.TotalVentasPersonalizadas = Convert.ToInt32(dataReader[0]);
                    ventaPersonalizadaDashboard.TotalVentasPersonalizadasMensual = Convert.ToInt32(dataReader[1]);
                }
            }

            conexion.Close();

            return ventaPersonalizadaDashboard;
        }

        public DTOIngresoDashboard ObtenerIngresos()
        {
            var ingresosDashboard = new DTOIngresoDashboard();

            SqlCommand command = new SqlCommand("SP_Obtener_Ingresos", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            conexion.Open();

            var dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    ingresosDashboard.TotalIngresos = Convert.ToInt32(dataReader[0]);
                    ingresosDashboard.TotalIngresosMensual = Convert.ToInt32(dataReader[1]);
                }
            }

            conexion.Close();

            return ingresosDashboard;
        }

        public DTOVisualizacionDashboard ObtenerVisualizaciones()
        {
            var visualizacionDashboard = new DTOVisualizacionDashboard();

            SqlCommand command = new SqlCommand("SP_Consultar_Visualizaciones", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 600
            };

            conexion.Open();
           
            var dataReader = command.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    visualizacionDashboard.TotalVisualizaciones = Convert.ToInt32(dataReader[0]);
                    visualizacionDashboard.TotalVisualizacionesMes = Convert.ToInt32(dataReader[1]);
                }
            }

            conexion.Close();

            return visualizacionDashboard;
            
        }

        private static void PrepararDatosParaGuardadoVisualizacion(SqlCommand sqlCommand, DtoVisualizacion dtoVisualizacion)
        {
            sqlCommand.Parameters.AddWithValue("@nombreModulo", dtoVisualizacion.VS_NombreModulo);
            sqlCommand.Parameters.AddWithValue("@fechaRegistro", dtoVisualizacion.DTS_FechaRegistro);
            sqlCommand.Parameters.AddWithValue("@maquina", dtoVisualizacion.VS_Maquina);
        }
        
    }
}
