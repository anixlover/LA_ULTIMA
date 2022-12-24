using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get 
            {
                //Conexion Maciel
                //return @"data source=HELLO; initial catalog=BD_SWCPEDR; integrated security=SSPI;";

                //Conexion Ana
                //return @"data source=DESKTOP-4LVLNRM; initial catalog=BD_SWCPEDR; integrated security=SSPI;";

                //Conexion Alvaro
                //return "data source=DESKTOP-IAELG6V\\SQLEXPRESS; initial catalog=BD_SWCPEDR; integrated security=SSPI;";

                //Conexion Mirko
                return @"Data Source=(Local);Initial Catalog=BD_SWCPEDR;Integrated Security=True";

                //Conexion André
                //return @"data source=LAPTOP-I2LRHJOD; initial catalog=BD_SWCPEDR; integrated security=SSPI;";
            }
        }
    }
}
