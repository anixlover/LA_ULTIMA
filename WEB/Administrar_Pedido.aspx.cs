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
    public partial class Administrar_Pedidos : System.Web.UI.Page
    {
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoMolduraXUsuario dtomxu = new DtoMolduraXUsuario();
        DtoPago objDtoPago = new DtoPago();
        CtrPago objCtrPago = new CtrPago();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
                dtomxu.FK_IS_Cod = Convert.ToInt32(Session["idSolicitudMXU"]);
                gvSolicitudes.DataBind();
                OpcionesSolicitudEstado();
            }
        }

        public void OpcionesSolicitudEstado()
        {
            DataSet ds = new DataSet();
            ds = objCtrSolicitud.OpcionesSolicitudEstado();
            ddltipo.DataSource = ds;
            ddltipo.DataTextField = "VSE_Nombre";
            ddltipo.DataValueField = "VSE_Nombre";
            ddltipo.DataBind();
            ddltipo.Items.Insert(0, new ListItem("Todos", "Todos"));

        }
        protected void gvSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var columna = gvSolicitudes.DataKeys[index].Values;
            int sol = Convert.ToInt32(columna[0].ToString());
            //int solMXU = Convert.ToInt32(columna[3].ToString());
            string dni = columna[2].ToString();
            switch (e.CommandName)
            {
                case "Ver detalles":
                    Session["clienteDNI"] = dni;
                    Session["idSolicitudPago"] = sol;
                    Session["estado"] = "0";
                    Response.Redirect("Detalles_Solicitud.aspx");
                    break;
                case "Evaluar": 
                    Session["idSolicitudPago"] = sol;
                    Response.Redirect("EvaluarPago.aspx");
                    break;
                case "asignar fecha":
                    Session["idSolicitudPago"] = sol;
                    Session["clienteDNI"] = dni;
                    Session["estado"] = "2";
                    Response.Redirect("Detalles_Solicitud2.aspx");
                    break;
                case "despachar":
                    objDtoSolicitud.PK_IS_Cod = sol;
                    objCtrSolicitud.Despachar(objDtoSolicitud);
                    gvSolicitudes.DataSource= objCtrSolicitud.ListaSolicitudes();
                    gvSolicitudes.DataBind();
                    UpdateSolicitudes.Update();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Pedido Despachado!',text: 'Datos ENVIADOS!!'})", true);
                    break;
                case "Recibir Restante":
                    objDtoPago.FK_IS_Cod = sol;
                    objCtrPago.ExistenciaPago(objDtoPago);
                    lblRestante.Text = (objDtoPago.DP_ImporteRestante).ToString();
                    lblidsol.Text= sol.ToString();
                    break;
            }
        }
        protected bool ValidacionEstado(string estado)
        {
            return estado == "En revisión de Pago";
        }
        protected bool ValidacionEstado2(string estado)
        {
            return estado == "Por asignar fecha";
        }
        protected bool validacionEstado3(string id)
        {
            objDtoPago.FK_IS_Cod = int.Parse(id);
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
            objCtrPago.ExistenciaPago(objDtoPago);
            return objDtoPago.DP_ImporteRestante == 0.00 && objDtoSolicitud.FK_ISE_Cod==11;//esta todo pagado y esta en espado de terminado
        }
        protected bool validacionEstado4(string id)
        {
            objDtoPago.FK_IS_Cod = int.Parse(id);
            objDtoSolicitud.PK_IS_Cod = int.Parse(id);
            objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
            objCtrPago.ExistenciaPago(objDtoPago);
            return objDtoPago.DP_ImporteRestante >0.00 && objDtoPago.IP_TipoPago==1 && objDtoSolicitud.FK_ISE_Cod == 11;//esta todo pagado y esta en espado de terminado
        }
        protected void ddltipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ddltipo.Text;
            if (tipo == "Todos")
            {
                gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
                gvSolicitudes.DataBind();
            }
            else
                gvSolicitudes.DataSource = objCtrSolicitud.Listar_Solicitud_tipo(tipo);
            gvSolicitudes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            objDtoPago.FK_IS_Cod = int.Parse(lblidsol.Text);
            objCtrPago.ExistenciaPago(objDtoPago);
            if (txtRestante.Text==""|txtRestante.Text.Contains("e")|double.Parse(txtRestante.Text)<objDtoPago.DP_ImporteRestante)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'no se aceptan ESPACIOS VACIOS o VALORES INVALIDOS!!'})", true);
                return;
            }
            double vuelto = double.Parse(txtRestante.Text) - objDtoPago.DP_ImporteRestante;
            objCtrPago.AgregarRestante(objDtoPago);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Pedido PAGADO!',text: 'VUELTO A ENTREGAR: S/."+ vuelto + "!!'}).then(cerrarModal())", true);
        }

        protected void gvSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string tipo = ddltipo.Text;

            gvSolicitudes.PageIndex = e.NewPageIndex;
            
            if (tipo == "Todos")
            {
                gvSolicitudes.DataSource = objCtrSolicitud.ListaSolicitudes();
                gvSolicitudes.DataBind();
            }
            else
            {
                gvSolicitudes.DataSource = objCtrSolicitud.Listar_Solicitud_tipo(tipo);
                gvSolicitudes.DataBind();
            }
             
        }
    }
}
