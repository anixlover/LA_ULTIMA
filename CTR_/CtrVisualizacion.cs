using DAO_;
using DTO;
using DTO.Visualizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
    public class CtrVisualizacion
    {
        private readonly DaoVisualizacion daoVisualizacion;

        public CtrVisualizacion()
        {
            daoVisualizacion = new DaoVisualizacion();
        }

        public void GuardarVisualizacionUsuario(DtoVisualizacion dtoVisualizacion)
        {
            try
            {
                daoVisualizacion.GuardarVisualizacionUsuario(dtoVisualizacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public DTOVisualizacionDashboard ObtenerVisualizaciones()
        {
            try
            {
                return daoVisualizacion.ObtenerVisualizaciones();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
