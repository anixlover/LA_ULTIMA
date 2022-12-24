using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CtrMolduraXUsuario
    {
        DaoMolduraXUsuario objDaoMolduraXUsuario;
        public CtrMolduraXUsuario()
        {
            objDaoMolduraXUsuario = new DaoMolduraXUsuario();
        }
        public void registrarNuevaMoldura(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.InsertarMolduraxUsuario(objDtoMolduraxUsuario);
        }
        public void actualizarExistencia(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actulizarExistenciaMXU(objDtoMolduraxUsuario);
        }
        public bool ExistenciaMXU(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.ExistenciaMXU(objDtoMolduraXUsuario);
        }
            public DataTable listarMoldurasxusuario(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ListarMXU(objdtoMolduraxUsuario);
        }
        public DataTable ListarMoldurasXsolicitud(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ListaMoldurasSolicitud(objdtoMolduraxUsuario);
        }
        public void eliminarMXU(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.eliminarMXU(objdtoMolduraxUsuario);
        }
        public DataTable ListarSolicitudesxDNI(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI(objDtoMolduraXUsuario);
        }        
        public DataTable ListarMoldurasxDNI_y_Estado(DtoMolduraXUsuario objDtoMolduraXUsuario, int estado)
        {
            return objDaoMolduraXUsuario.SelectSolicitudesxDNI_y_Estado(objDtoMolduraXUsuario, estado);
        }
        public void obtenerMoldura(DtoMolduraXUsuario objdtoMolduraxUsuario, DtoMoldura objm, DtoTipoMoldura tm)
        {
            objDaoMolduraXUsuario.ObtenerMXU(objm, objdtoMolduraxUsuario, tm);
        }
        public void actualizarMXU(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actualizarMXU(objdtoMolduraxUsuario);
        }
        public void actualizarMXUSol(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actualizarMXUSol(objdtoMolduraxUsuario);
        }
        public bool obtenerMXUxCodigo(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            return objDaoMolduraXUsuario.ExistenciaMXU_x_Cod(objdtoMolduraxUsuario);
        }
        public void actualizarMXUxCod(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.UpdateMXU_x_codigo(objdtoMolduraxUsuario);
        }
        public void actualizarMXU_Estado_enProceso(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.UpdateMXU_x_codigoSOL(objdtoMolduraxUsuario);
        }
        public void AgregarMoldes_a_usar(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.UpdateCantMoldesMXU_x_codigo(objdtoMolduraxUsuario);
        }
        public void DevolverMoldes(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.UpdateCantMoldesCeroMXU_x_codigo(objdtoMolduraxUsuario);
        }
        public void registrarNuevaMoldura2(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.InsertarMolduraxUsuariox2(objDtoMolduraxUsuario);
        }
        public void registrarMXU(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.registrarMXU(objDtoMolduraxUsuario);
        }
        public void registrarMXUP(DtoMolduraXUsuario objDtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.registrarMXUP(objDtoMolduraxUsuario);
        }

        public void actualizarMXUSolP(DtoMolduraXUsuario objdtoMolduraxUsuario)
        {
            objDaoMolduraXUsuario.actualizarMXUSolP(objdtoMolduraxUsuario);
        }
        public bool ExistenciaMXU2(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.ExistenciaMXU2(objDtoMolduraXUsuario);
        }
        public int CantidadMoldurasxSolicitud(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.CantMolduras(objDtoMolduraXUsuario);
        }
        public int CantidadMoldurasDespachadasxSolicitud(DtoMolduraXUsuario objDtoMolduraXUsuario)
        {
            return objDaoMolduraXUsuario.CantMoldurasDespachadas(objDtoMolduraXUsuario);
        }
    }
}
