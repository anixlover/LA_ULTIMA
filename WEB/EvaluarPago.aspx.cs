using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using DAO;

namespace WEB
{
    public partial class EvaluarPago : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection(ConexionBD.CadenaConexion);
        Log _log = new Log();
        DtoPago dtopago = new DtoPago();
        DtoSolicitud dtosol = new DtoSolicitud();
        DtoMolduraXUsuario dtomxu = new DtoMolduraXUsuario();
        Dto_Voucher dtovoucher = new Dto_Voucher();
        DtoUsuario dtousu = new DtoUsuario();
        CtrSolicitud ctrsol = new CtrSolicitud();
        CtrUsuario ctrusu = new CtrUsuario();
        Ctr_Voucher ctrvoucher = new Ctr_Voucher();
        CtrPago ctrpago = new CtrPago();
        int solicitud = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    solicitud = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    obtenerVoucher();
                    cargarDatosVpoucher();
                    CargarMolduras2();
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("EvaluarPago", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }
        }

        public void CargarMolduras2()
        {
            dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);
            if (ctrsol.leerSolicitudTipo(dtosol))
            {
                if (dtosol.VS_TipoSolicitud == "Personalizado por catalogo" || dtosol.VS_TipoSolicitud == "Catalogo")
                {
                    ctrsol.LeerSolicitud(dtosol);
                    gvDetalleSolicitud2.Visible = false;
                    gvDetalles.Visible = true;
                    
                    gvDetalles.DataSource = ctrsol.ListaMolduras(dtosol);
                    gvDetalles.DataBind();
                }
                if (dtosol.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    ctrsol.leerSolicitudDiseñoPersonal(dtosol);

                    gvDetalleSolicitud2.Visible = true;
                    gvDetalles.Visible = false;
                    gvDetalleSolicitud2.DataSource = ctrsol.ListaMoldurasxDiseñoPropio(dtosol);
                    gvDetalleSolicitud2.DataBind();
                    
                }
            }
        }
        public void cargarDatosVpoucher()
        {
            dtopago.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);
            ctrpago.ExistenciaPago(dtopago);
            dtovoucher.FK_VP_Cod = dtopago.PK_VP_Cod;
            ctrvoucher.ExistenciaVoucherxCodPago(dtovoucher);
            string strbase64 = Convert.ToBase64String(dtovoucher.VBV_Foto);
            Image1.ImageUrl = "data:image/png;base64," + strbase64;
        }
        protected void ddl_TipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void obtenerVoucher()
        {
            dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            dtopago.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            dtovoucher.PK_VV_NumVoucher = ctrsol.HayPago(dtosol);
            ctrsol.LeerSolicitudTipo(dtosol);
            if (ctrvoucher.hayVoucher(dtovoucher))
            {
                //string image = Convert.ToBase64String(dtovoucher.VBV_Foto);
                //Image1.ImageUrl = "data:Image/png;base64," + image;
                ctrpago.HayRUC(dtopago);
                txtNumOperacion.Text = dtovoucher.PK_VV_NumVoucher.ToString();
                txtmonto.Text = dtovoucher.DV_ImporteDepositado.ToString();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_decision.SelectedValue == "0")
                {
                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //muestra aviso que no se selecciono ninguna opcion
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'UPS! No selecciono ninguna opcion!',text: 'SELECCIONAR OPCION!!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    //Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage4()");
                }
                if (ddl_decision.SelectedValue == "1")
                {
                    //dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    //ctrsol.Actualizar_Estado_Solicitud(dtosol);
                    //_log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    ////actualiza correctamente a aprobado
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Actualizado Correctamente!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    ////Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage2()");
                    dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    ctrsol.leerSolicitudTipo(dtosol);
                    if (dtosol.VS_TipoSolicitud == "Catalogo" | dtosol.VS_TipoSolicitud == "Personalizado por catalogo")
                    {
                        ctrsol.Actualizar_Estado_Solicitud(dtosol);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Actualizado Correctamente!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    }
                    else if (dtosol.VS_TipoSolicitud == "Personalizado por diseño propio")
                    {
                        ctrsol.Actualizar_Estado_SolicitudPDP(dtosol);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Actualizado Correctamente!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    }
                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                }
                if (ddl_decision.SelectedValue == "2")
                {
                    dtosol.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
                    ctrusu.EnviarCorreoReportado(dtosol);
                    _log.CustomWriteOnLog("EvaluarPago", "DDL = " + ddl_decision.Text);
                    //reporta la solicitud
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Se le reporto al usuario correctamente!',text: 'Pulsa el botón y se te redirigirá!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    //Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage3()");
                }
            }
            catch (Exception ex)
            {
                Utils.AddScriptClientUpdatePanel(updPanelddl, "showSuccessMessage1()");
                _log.CustomWriteOnLog("EvaluarPago", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }

       }
    }
}