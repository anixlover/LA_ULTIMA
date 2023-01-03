using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace WEB
{
    public partial class ConsultarEstadosPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DNIUsuario"] == null)
                {
                    Response.Redirect("~/IniciarSesion.aspx");
                }
                else
                {
                    UpdatePanel.Update();
                    CargarDDL();
                    CargarSolicitudes();
                }                
            }
        }

        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoMolduraXUsuario objDtoMolduraxUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraxUsuario = new CtrMolduraXUsuario();
        CtrSolicitudEstado objCtrSolicitudEstados = new CtrSolicitudEstado();
        CtrMoldura objctrMoldura = new CtrMoldura();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        Log _log = new Log();
        protected Boolean ValidacionEstado1(string estado)
        {
            return estado == "Pendiente de pago";
        }
        protected Boolean ValidacionEstado2(string estado)
        {
            return estado == "Observada";
        }
        protected Boolean ValidacionEstado3(string estado, string tipo)
        {
            return estado == "Pendiente de revisión de fecha" & tipo== "Personalizado por diseño propio";
        }
        protected Boolean ValidacionEstado4(string estado)
        {
            return estado == "Personalizado por diseño propio";
        }
        protected Boolean ValidacionEstado5(string estado)
        {
            return estado == "En proceso";
        }
        protected Boolean ValidacionEstado6(string estado)
        {
            return estado == "Con retraso";
        }
        protected Boolean ValidacionEstado7(string estado, string tipo)
        {
            return estado == "Rechazada" & tipo == "Personalizado por diseño propio";
        }
        protected Boolean ValidacionEstado8(string tipo, string estado)
        {
            return tipo == "Personalizado por diseño propio" & estado != "En aprobación";
        }
        protected Boolean ValidacionPersonalizado(string id)
        {
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
            return objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio";
        }
        public void CargarSolicitudes() 
        {
            objDtoMolduraxUsuario.FK_VU_Dni = Session["DNIUsuario"].ToString();
            gvPedidos.DataSource = objCtrMolduraxUsuario.ListarSolicitudesxDNI(objDtoMolduraxUsuario);
            gvPedidos.DataBind();
        }
        public void CargarDDL()
        {
            ddlEstadoSolicitud.DataSource = objCtrSolicitudEstados.ListarEstados();
            ddlEstadoSolicitud.DataTextField = "VSE_Nombre";
            ddlEstadoSolicitud.DataValueField = "PK_ISE_Cod";
            ddlEstadoSolicitud.DataBind();
            ddlEstadoSolicitud.Items.Insert(0, new ListItem("Todos", "Todos"));
        }
        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver detalles")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;                
                CargarMolduras(id);
                lblid.Text = id;
            }
            if (e.CommandName == "Ver proceso")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                CargarMoldurasProceso(id);
                lblid.Text = id;
            }
            if (e.CommandName == "Pago")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/RealizarCompra.aspx?sol="+id);
            }
            if (e.CommandName == "Ver incidencias")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvIncidencias.Columns[0].Visible = true;
                    gvIncidencias.Columns[1].Visible = false;
                    gvIncidencias.Columns[3].Visible = false;
                    gvIncidencias.DataSource = objCtrSolicitud.MostrarIncidentes(objDtoSolicitud);
                    gvIncidencias.DataBind();
                }
                else
                {
                    gvIncidencias.Columns[1].Visible = true;
                    gvIncidencias.Columns[0].Visible = false;
                    gvIncidencias.Columns[3].Visible = true;
                    gvIncidencias.DataSource = objCtrSolicitud.MostrarIncidentes(objDtoSolicitud);
                    gvIncidencias.DataBind();
                }
            }
            if(e.CommandName=="Aceptar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                objCtrSolicitud.AceptarImportePPDP(objDtoSolicitud);
                CargarSolicitudes();
                UpdatePanel.Update();
            }
            if (e.CommandName == "Rechazar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPedidos.Rows[index];
                string id = row.Cells[0].Text;
                objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                objCtrSolicitud.Rechazar(objDtoSolicitud);
                CargarSolicitudes();
                UpdatePanel.Update();
            }
            if(e.CommandName == "Recotizar")
            {
                _log.CustomWriteOnLog("Consultar Estado Pago", "-----------------------ENTRO A COTIZACIÓN----------------------");
                _log.CustomWriteOnLog("Consultar Estado Pago", "Obtenemos Datos Pedido");
                
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvPedidos.Rows[index];
                    Button b = (Button)row.FindControl("btnGetDatos");
                    string id = row.Cells[0].Text;
                    //lblid.Text = id;
                    objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                    
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //var colsNoVisible = gvPedidos.DataKeys[index].Values;
                    //string id = colsNoVisible[0].ToString();

                    //objDtoSolicitud.PK_IS_Cod = int.Parse(id);

                    DtoMoldura objDtoMoldura = new DtoMoldura();
                    DtoTipoMoldura dtoTipoMoldura = new DtoTipoMoldura();
                    CtrSolicitud objCtrSolicitud2 = new CtrSolicitud();

                    objCtrMolduraxUsuario.obtenerMoldura(objDtoMolduraxUsuario, objDtoMoldura, dtoTipoMoldura);
                    objctrMoldura.ObtenerMoldura(objDtoMoldura, dtoTipoMoldura);
                    txtcodigoModal.Text = objDtoSolicitud.PK_IS_Cod.ToString();
                    objCtrSolicitud2.Select_Solicitud_ID(objDtoSolicitud);
                    //txtcodM.Text = objDtoMoldura.PK_IM_Cod.ToString();
                    txtTMModal.Text = dtoTipoMoldura.VTM_Nombre;
                    txtlargo.Text = objDtoSolicitud.DS_Largo.ToString();
                    txtancho.Text = objDtoSolicitud.DS_Ancho.ToString();
                    txtcantidadModal.Text = objDtoSolicitud.IS_Cantidad.ToString();
                    txtDescripcionModal.Text = objDtoSolicitud.VS_Comentario;
                    txtCotización.Text = objDtoSolicitud.VS_Mcotizacion;
                    txtprecior.Value = objDtoMoldura.DM_Precio.ToString();
                    objDtoSolicitud.VBS_Imagen = (byte[])objCtrSolicitud.RetornarImagenDiseñoPersonalizado(objDtoSolicitud).Rows[0][0];
                    Img1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(objDtoSolicitud.VBS_Imagen);
                    UpdatePanel.Update();
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion PK_IS_Cod" + objDtoSolicitud.PK_IS_Cod.ToString());
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion tipo moldura" + dtoTipoMoldura.VTM_Nombre);
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion largo" + objDtoSolicitud.DS_Largo.ToString());
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion ancho" + objDtoSolicitud.DS_Ancho.ToString());
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion cantidad" + objDtoSolicitud.IS_Cantidad.ToString());
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion comentario" + objDtoSolicitud.VS_Comentario);
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion cotizacion" + objDtoSolicitud.VS_Mcotizacion);

                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("Consultar Estado Pago", ex.Message + "Stac" + ex.StackTrace);

                    throw;
                }
            }
            if (e.CommandName == "Cotizacion")
            {
                _log.CustomWriteOnLog("Consultar Estado Pago", "-----------------------ENTRO A DETALLES DE COTIZACIÓN----------------------");
                _log.CustomWriteOnLog("Consultar Estado Pago", "Obtenemos Detalle");
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvPedidos.Rows[index];
                    Button b = (Button)row.FindControl("btnGetDatos");
                    string id = row.Cells[0].Text;
                    objDtoSolicitud.PK_IS_Cod = int.Parse(id);

                    DtoMoldura objDtoMoldura = new DtoMoldura();
                    DtoTipoMoldura dtoTipoMoldura = new DtoTipoMoldura();
                    CtrSolicitud objCtrSolicitud2 = new CtrSolicitud();
                    //Select_Detalle_Cotizacíon_ID
                    objCtrSolicitud2.Select_Detalle_Cotizacíon_ID(objDtoSolicitud);
                    txtDetalleCotizacion.Text = objDtoSolicitud.VS_Mcotizacion;
                    _log.CustomWriteOnLog("Consultar Estado Pago", "Cotizacion: " + objDtoSolicitud.VS_Mcotizacion);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("Consultar Estado Pago", ex.Message + "Stac" + ex.StackTrace);
                    throw;
                }
            }
        }
        public void CargarMolduras(string id)
        {
            objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(id);
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            if (objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud))
            {
                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    gvPersonalizado.Visible = false;
                    gvPersonalizado2.Visible = false;
                    gvDetalles.Visible = true;
                    gvProceso.Visible = false;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    gvDetalles.DataSource = objCtrMolduraxUsuario.ListarMoldurasXsolicitud(objDtoMolduraxUsuario);
                    gvDetalles.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvPersonalizado.Visible = true;
                    gvDetalles.Visible = false;
                    gvProceso.Visible = false;
                    gvPersonalizado2.Visible = false;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    gvPersonalizado.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado.DataBind();
                }
            }
        }
        public void CargarMoldurasProceso(string id)
        {
            objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(id);
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            if (objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud))
            {

                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    gvPersonalizado.Visible = false;
                    gvPersonalizado2.Visible = false;
                    gvDetalles.Visible = false;
                    gvProceso.Visible = true;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    gvProceso.DataSource = objCtrMolduraxUsuario.ListarMoldurasXsolicitud(objDtoMolduraxUsuario);
                    gvProceso.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvPersonalizado.Visible = false;
                    gvDetalles.Visible = false;
                    gvProceso.Visible = false;
                    gvPersonalizado2.Visible = true;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    gvPersonalizado2.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado2.DataBind();
                }
            }
        }

        protected void ddlEstadoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDtoMolduraxUsuario.FK_VU_Dni = Session["DNIUsuario"].ToString();
            if (ddlEstadoSolicitud.SelectedValue.ToString()=="Todos")
            {
                gvPedidos.DataSource = objCtrMolduraxUsuario.ListarSolicitudesxDNI(objDtoMolduraxUsuario);
                gvPedidos.DataBind();
            }
            else
            {
                int estado = Convert.ToInt32(ddlEstadoSolicitud.SelectedValue);
                gvPedidos.DataSource = objCtrMolduraxUsuario.ListarMoldurasxDNI_y_Estado(objDtoMolduraxUsuario, estado);
                gvPedidos.DataBind();
            }            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("Consultar Estado Pago", "-----------------------ENTRO AL BOTON RECOTIZAR----------------------");
                objDtoSolicitud.PK_IS_Cod = int.Parse(txtcodigoModal.Text);
                if (txtlargo.Text == "" | txtancho.Text == "" | txtcantidadModal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                    return;
                }
                else if (int.Parse(txtcantidadModal.Text) <= 0 | int.Parse(txtlargo.Text) <= 0 | int.Parse(txtancho.Text) <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Numero INVALIDO!!'})", true);
                    return;
                }
                objDtoSolicitud.DS_Largo = double.Parse(txtlargo.Text);
                objDtoSolicitud.DS_Ancho = double.Parse(txtancho.Text);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtcantidadModal.Text);
                objDtoSolicitud.VS_Comentario = txtDescripcionModal.Text;

                objCtrSolicitud.Actualizar_Recotizacion(objDtoSolicitud);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Evaluación Realizada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='ConsultarEstadosPago.aspx'})", true);
                objDtoMolduraxUsuario.FK_VU_Dni = Session["DNIUsuario"].ToString();
                UpdatePanel.Update();
                gvPersonalizado2.DataSource = objCtrMolduraxUsuario.ListarSolicitudesxDNI(objDtoMolduraxUsuario);
                Utils.AddScriptClientUpdatePanel(UpdatePanel, "showSuccessMessage2()");
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Consultar Estado Pago", ex.Message + "Stac" + ex.StackTrace);

                throw;
            }
            
        }
    }
}