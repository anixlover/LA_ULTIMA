using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;

namespace WEB
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
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
                    cargarSolicitudes();
                }
            }            
        }
        protected Boolean ValidacionEstado(string estado)
        {
            return estado == "En aprobación";
        }
        public void cargarSolicitudes()
        {
            gvPersonalizado.DataSource = objCtrSolicitud.ListarSolicittudesDiseñoPropioEvaluar();
            gvPersonalizado.DataBind();
        }

        protected void gvPersonalizado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Log _log = new Log();
            if (e.CommandName == "Evaluar")
            {
                try
                {
                    //int index = Convert.ToInt32(e.CommandArgument);
                    //var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                    //string id = colsNoVisible[0].ToString();
                    //string Nombre = colsNoVisible[1].ToString();
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvPersonalizado.Rows[index];
                    Button b = (Button)row.FindControl("btnGetDatos");
                    string id = row.Cells[1].Text;
                    lblid.Text = id;
                    objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                    lblLargo.Text= objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud).Rows[0][2].ToString();
                    lblAncho.Text= objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud).Rows[0][3].ToString();
                    lblcantidad.Text=objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud).Rows[0][5].ToString();
                    lblprecio.Text= objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud).Rows[0][6].ToString();
                    objDtoSolicitud.VBS_Imagen =(byte[])objCtrSolicitud.RetornarImagenDiseñoPersonalizado(objDtoSolicitud).Rows[0][0];
                    lblid.Text = id;
                    Img1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(objDtoSolicitud.VBS_Imagen);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("GestionCatalogo", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        protected void btnAsignarFecha_Importe_Click(object sender, EventArgs e)
        {
            objDtoSolicitud.PK_IS_Cod = int.Parse(lblid.Text);
            if (txtImporte.Text == ""| txtNdias.Text == "" )
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            else if (int.Parse(txtNdias.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Numero de día INVALIDO!!'})", true);
                return;
            }
            objDtoSolicitud.IS_Ndias = int.Parse(txtNdias.Text);
            objDtoSolicitud.DS_ImporteTotal = double.Parse(txtImporte.Text);
            objCtrSolicitud.AsignarFecha_e_Importe(objDtoSolicitud);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Evaluación Realizada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='EvaluarPedidosPersonalizados.aspx'})", true);
        }

        protected void btnRechazar_Click1(object sender, EventArgs e)
        {
            string id = lblid.Text;
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            objCtrSolicitud.Rechazar(objDtoSolicitud);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Solicitud Rechazada!',text: '!'}).then(function(){window.location.href='EvaluarPedidosPersonalizados.aspx'})", true);
        }

        protected void btnMandarObservacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtObservacion.Text == null | txtObservacion.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                    return;
                }
                else
                {
                    objDtoSolicitud.PK_IS_Cod = int.Parse(lblid.Text);
                    objDtoSolicitud.VS_Comentario = txtObservacion.Text;
                    objCtrSolicitud.MandarObservacion(objDtoSolicitud);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Observación Realizada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='EvaluarPedidosPersonalizados.aspx'})", true);
                }
            }
            catch (Exception Ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'"+Ex.Message+"'})", true);
                throw;
            }
        }

        protected void gvPersonalizado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPersonalizado.PageIndex = e.NewPageIndex;
            gvPersonalizado.DataSource = objCtrSolicitud.ListarSolicittudesDiseñoPropioEvaluar();
            gvPersonalizado.DataBind();
        }
    }
}