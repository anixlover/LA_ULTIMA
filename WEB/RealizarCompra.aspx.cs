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
    public partial class RealizarCompra : System.Web.UI.Page
    {
        DtoDatoFactura objDtoDatoFactura = new DtoDatoFactura();
        CtrDatoFactura objCtrDatoFactura = new CtrDatoFactura();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoPago objDtoPago = new DtoPago();
        CtrPago objCtrPago = new CtrPago();
        DtoMolduraXUsuario objDtoMolduraXUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraXUsuario = new CtrMolduraXUsuario();
        Dto_Voucher objDtoVoucher = new Dto_Voucher();
        Ctr_Voucher objCtrVoucher = new Ctr_Voucher();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["DNIUsuario"] == null | Request.Params["sol"] == null)
                {
                    Response.Redirect("~/IniciarSesion.aspx");
                }
                else
                {
                    CargarMolduras();
                    CargarRUCS();
                    txtNuevoRUC.Visible = false;
                    ddlRUC.Visible = false;
                    chbNuevoRUC.Visible = false;
                    lblTitulo1.Visible = false;
                }
            }
        }

        protected void rbBoleta_CheckedChanged(object sender, EventArgs e)
        {
            ddlRUC.Visible = false;
            chbNuevoRUC.Visible = false;
            chbNuevoRUC.Checked = false;
            lblTitulo1.Visible = false;
            txtNuevoRUC.Visible = false;
        }

        protected void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            ddlRUC.Visible = true;
            lblTitulo1.Visible = true;
            chbNuevoRUC.Visible = true;
            txtNuevoRUC.Visible = true;
        }
        public void cargarEvento()
        {
            if (chbNuevoRUC.Checked == true)
            {
                txtNuevoRUC.Visible = true;
                ddlRUC.Visible = false;
            }
            else
            {
                txtNuevoRUC.Visible = false;
                ddlRUC.Visible = true;
            }
        }
        protected void chbNuevoRUC_CheckedChanged(object sender, EventArgs e)
        {
            cargarEvento();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            double costo = double.Parse(lblcosto.Text);
            objDtoDatoFactura.FK_VU_Dni = Session["DNIUsuario"].ToString();
            objDtoSolicitud.PK_IS_Cod = int.Parse(Request.Params["sol"]);
            objDtoDatoFactura.VDF_Ruc = txtNuevoRUC.Text;
            objDtoVoucher.PK_VV_NumVoucher = txtNumOP.Text;
            if (hftxtimg.Value.ToString() == "vacio")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Suba Imagen del VOUCHER!!'})", true);
                return;
            }
            else if (txtNumOP.Text == "" | txtImporte.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            else if (rbBoleta.Checked == false && rbFactura.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Seleccione BOLETA o FACTURA!!'})", true);
                return;
            }
            else if (chbNuevoRUC.Checked == true & rbFactura.Checked == true & txtNuevoRUC.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete espacios en BLANCO!!'})", true);
                return;
            }
            else if (chbNuevoRUC.Checked == false & rbFactura.Checked == true & ddlRUC.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'No hay RUC'S!!'})", true);
                return;
            }
            else if (double.Parse(txtImporte.Text) < costo / 2 | double.Parse(txtImporte.Text) > costo| txtImporte.Text.Contains("e"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Importe INVALIDO!!'})", true);
                return;
            }
            else if (objCtrDatoFactura.formatoRUC(objDtoDatoFactura) == false && rbFactura.Checked == true && chbNuevoRUC.Checked == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'RUC INVALIDO!!'})", true);
                return;
            }
            else if (objCtrVoucher.hayVoucher(objDtoVoucher))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Número de operación ya Existente!!'})", true);
                return;
            }
            objDtoVoucher.VV_Comentario = "";
            string cadena = hftxtimg.Value.ToString();
            List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
            byte[] bimagen = imagen.ToArray();
            objDtoVoucher.VBV_Foto = bimagen;
            if (rbBoleta.Checked == true)
            {
                objDtoPago.VP_RUC = "";
                objDtoPago.IP_TipoCertificado = 1;
            }
            if (chbNuevoRUC.Checked == false & rbFactura.Checked == true)
            {
                objDtoPago.VP_RUC = ddlRUC.Text;
                objDtoPago.IP_TipoCertificado = 2;
            }
            if (chbNuevoRUC.Checked == true)
            {
                objCtrDatoFactura.RegistrarDatoFatcura(objDtoDatoFactura);
                objDtoPago.VP_RUC = txtNuevoRUC.Text;
                objDtoPago.IP_TipoCertificado = 2;
            }
            objDtoPago.DP_ImportePagado = double.Parse(txtImporte.Text);
            objDtoVoucher.DV_ImporteDepositado= double.Parse(txtImporte.Text);
            objDtoPago.DP_ImporteRestante = costo - Convert.ToDouble(txtImporte.Text);
            if (Convert.ToDouble(txtImporte.Text) >= (costo / 2) & Convert.ToDouble(txtImporte.Text)<costo)
            {
                objDtoPago.IP_TipoPago = 1;
            }
            if (Convert.ToDouble(txtImporte.Text) == costo)
            {
                objDtoPago.IP_TipoPago = 2;
            }
            objDtoPago.FK_IS_Cod = int.Parse(Request.Params["sol"]);
            objCtrPago.RegistrarPago(objDtoPago);
            objCtrPago.ExistenciaPago(objDtoPago);
            objDtoVoucher.FK_VP_Cod = objDtoPago.PK_VP_Cod;            
            objCtrVoucher.RegistrarVoucher(objDtoVoucher);
            objCtrSolicitud.Actualizar_a_EstadoRevisiónPago(objDtoSolicitud);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='ConsultarEstadosPago.aspx'})", true);
        }
        public void CargarMolduras()
        {
            //objDtoMolduraXUsuario.FK_IS_Cod = int.Parse(Session["idSolicitudPago"].ToString());
            objDtoMolduraXUsuario.FK_IS_Cod = int.Parse(Request.Params["sol"]);
            //objDtoSolicitud.PK_IS_Cod= int.Parse(Session["idSolicitudPago"].ToString());
            objDtoSolicitud.PK_IS_Cod = int.Parse(Request.Params["sol"]);
            if (objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud))
            {
                if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || objDtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    gvPersonalizado.Visible = false;
                    gvDetalles.Visible = true;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    lblcosto.Text = objDtoSolicitud.DS_ImporteTotal.ToString();
                    gvDetalles.DataSource = objCtrMolduraXUsuario.ListarMoldurasXsolicitud(objDtoMolduraXUsuario);
                    gvDetalles.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    gvPersonalizado.Visible = true;
                    gvDetalles.Visible = false;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    lblcosto.Text = objDtoSolicitud.DS_ImporteTotal.ToString();
                    gvPersonalizado.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado.DataBind();
                }
            }
        }
        public void CargarRUCS()
        {
            objDtoDatoFactura.FK_VU_Dni= Session["DNIUsuario"].ToString();
            ddlRUC.DataSource=objCtrDatoFactura.ListarRucs(objDtoDatoFactura);
            ddlRUC.DataTextField = "VDF_Ruc";
            ddlRUC.DataValueField = "VDF_Ruc";
            ddlRUC.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultarEstadosPago.aspx");
        }
    }
}