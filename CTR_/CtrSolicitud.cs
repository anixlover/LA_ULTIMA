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
    public class CtrSolicitud
    {
        DaoSolicitud objDaoSolicitud;
        public CtrSolicitud()
        {
            objDaoSolicitud = new DaoSolicitud();
        }
        public DataTable ListarSolicitudesTrabajdor()
        {
            return objDaoSolicitud.SelectSolicitudesTrabajador();
        }
        public bool LeerSolicitudTipo(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudTipo(objDtoSolicitud);
        }
        public bool LeerSolicitudImporte(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudImporte(objDtoSolicitud);
        }
        public bool leerSolicitudDiseñoPersonal(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPersonalizado(objDtoSolicitud);
        }
        public DataTable MostrarPedidoPersonalizado(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPropio(objDtoSolicitud);
        }
        public DataTable RetornarImagenDiseñoPersonalizado(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudDiseñoPropioIMG(objDtoSolicitud);
        }
        public DataTable ListaSolicitudes()
        {
            return objDaoSolicitud.SelectSolicitudes();
        }
        public DataSet OpcionesSolicitudEstado()
        {
            return objDaoSolicitud.desplegableSolicitudEstado();
        }
        public DataTable Listar_Solicitud_tipo(string tipo)
        {
            return objDaoSolicitud.SelectSolicitudes(tipo);
        }
        public void Actualizar_a_EstadoRevisiónPago(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_RevisióPago(objDtoSolicitud);
        }
        public string HayPago(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudPago(objsol);
        }
        public bool leerSolicitudTipo(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitudTipo(objsol);
        }
        public bool LeerSolicitud(DtoSolicitud objsol)
        {
            return objDaoSolicitud.SelectSolicitud(objsol);
        }
        public DataTable ListaMolduras(DtoSolicitud objsol)
        {
            return objDaoSolicitud.ListaMoldurasSolicitud(objsol);
        }
        public DataTable ListaMoldurasxDiseñoPropio(DtoSolicitud objsol)
        {
            return objDaoSolicitud.ListaMoldurasSolicitudXDiseñoPropio(objsol);
        }
        public DataTable ListarSolicittudesDiseñoPropioEvaluar()
        {
            return objDaoSolicitud.SelectSolicitudesDiseñoPropio_Clientes();
        }
        public void AsignarFecha_e_Importe(DtoSolicitud objsol)
        {
            objDaoSolicitud.UpdateSolicitudFecha_RevisionFecha(objsol);
        }
        public void Rechazar(DtoSolicitud objsol)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Rechazado(objsol);
        }
        public void Actualizar_Estado_Solicitud(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.Actualizar_Estado_SolicitudX1(objDtoSolicitud);
        }
        public void Actualizar_Estado_Solicitud2(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.Actualizar_Estado_SolicitudX2(objDtoSolicitud);
        }
        public void RegistrarSolicitud_LD(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD(objsolicitud);
        }
        public void MandarObservacion(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Observacion(objsolicitud);
        }
        public void RegistrarSolicitud_PxDP(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxPD(objsolicitud);
        }
        public void RegistrarSolicitud_PxC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PxC(objsolicitud);
        }
        public void RegistrarSolicitud_PExC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PExC(objsolicitud);
        }
        public void RegistrarSolicitud_LD2(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_LD2(objsolicitud);
        }
        public void ComenzarProceso(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.Update_Estado_SolicitudEnProceso(objsolicitud);
        }
        public int MoldurasConMoldeSolicitud(DtoSolicitud objsolicitud)
        {
            return objDaoSolicitud.SelectSolicitudMoldes(objsolicitud);
        }

        public void RegistrarSolcitud_PC(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolcitud_PC(objsolicitud);
        }

        public void registrarImgMoldura(byte[] arreglo, int id)
        {
            objDaoSolicitud.RegistrarImgSolicitud(arreglo, id);
        }

        public void RegistrarSolcitud_PP(DtoSolicitud objsolicitud)
        {
            objDaoSolicitud.RegistrarSolicitud_PP(objsolicitud);
        }
        public DataTable SolicitudesTerminadasEntreFechas(string fechaInicio, string fechaFin)
        {
            return objDaoSolicitud.SelectSolicitudesTerminadasBetween(fechaInicio, fechaFin);
        }
        public DataTable SolicitudesTerminadas()
        {
            return objDaoSolicitud.SelectSolicitudesTerminadas();
        }
        public double ImporteTotal()
        {
            return objDaoSolicitud.SelectImporteTotalSolicitudes();
        }
        public double ImporteTotalEntreFechas(string fechaInicio, string fechaFin)
        {
            return objDaoSolicitud.SelectImporteTotalSolicitudesEntreFechas(fechaInicio, fechaFin);
        }
        public int DiasRecojo(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectDiasSolicitudes(objDtoSolicitud);
        }
        public bool SolicitudFechaRegistro(DtoSolicitud objDtoSolicitud)
        {
            return objDaoSolicitud.SelectSolicitudFechaRegistro(objDtoSolicitud);
        }
        public void ActualizarFecha_Ndias(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateSolicitudFecha(objDtoSolicitud);
        }
        public DataTable MostrarIncidentes(DtoSolicitud objDtoSolicitud)
        {
           return objDaoSolicitud.SelectIncidentesxSolicitud(objDtoSolicitud);
        }
        public void Terminar(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateSolicitudFecha_Terminado(objDtoSolicitud);
        }
        public void Despachar(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Despachado(objDtoSolicitud);
        }
        public void AceptarImportePPDP(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.UpdateEstadoSolicitud_Pendiente_pago(objDtoSolicitud);
        }
        public void Actualizar_Estado_SolicitudPDP(DtoSolicitud objDtoSolicitud)
        {
            objDaoSolicitud.Actualizar_Estado_SolicitudX1PDP(objDtoSolicitud);
        }
    }
}
