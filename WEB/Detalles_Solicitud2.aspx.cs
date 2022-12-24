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
    public partial class Detalles_Solicitud2 : System.Web.UI.Page
    {
        DtoSolicitud dtoSolicitud = new DtoSolicitud();
        DtoUsuario dtoUsuario = new DtoUsuario();
        CtrUsuario ctrUsuario = new CtrUsuario();
        CtrSolicitud ctrSolicitud = new CtrSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtfecha.Visible = false;
                //lblfecha.Visible = false;
                //btnfehca.Visible = false;
                //lbldias.Visible = false;
                //CargarCliente();
                //asignar();
                CargarMolduras2();
                //asignar2();
            }
        }
        public void CargarMolduras2()
        {
            dtoSolicitud.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"]);
            //pendiente de pago A aprobado
            if (ctrSolicitud.leerSolicitudTipo(dtoSolicitud))
            {
                if (dtoSolicitud.VS_TipoSolicitud == "Personalizado por catalogo" || dtoSolicitud.VS_TipoSolicitud == "Catalogo")
                {
                    ctrSolicitud.LeerSolicitud(dtoSolicitud);
                    //imgPersonal.Visible = false;
                    //gvDetalleSolicitud.Visible = true;
                    //txtcomentario.Visible = false;
                    //lblcosto.Text = "S/ " + dtoSolicitud.DS_ImporteTotal.ToString();
                    gvDetalleSolicitud.DataSource = ctrSolicitud.ListaMolduras(dtoSolicitud);
                    gvDetalleSolicitud.DataBind();


                }
                if (dtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    ctrSolicitud.leerSolicitudDiseñoPersonal(dtoSolicitud);
                    gvDetalleSolicitud2.DataSource = ctrSolicitud.ListaMoldurasxDiseñoPropio(dtoSolicitud);
                    gvDetalleSolicitud2.DataBind();
                    //gvMolduras.Visible = false;
                    //imgPersonal.Visible = true;
                    //txtcomentario.Visible = true;
                    //lblcosto.Text = "Aproximado: S/" + dtoSolicitud.DS_PrecioAprox.ToString();
                    //string imagen = Convert.ToBase64String(dtoSolicitud.VBS_Imagen);
                    //imgPersonal.ImageUrl = "data:Image/png;base64," + imagen;
                    //txtcomentario.Text = dtoSolicitud.VS_Comentario;
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            dtoSolicitud.PK_IS_Cod = Convert.ToInt32(Session["idSolicitudPago"].ToString());
            //ctrSolicitud.Actualizar_Estado_Solicitud(dtoSolicitud);
            dtoSolicitud.VS_TipoSolicitud = "Personalizado por Catalogo";
            //dtoSolicitud.IS_Cantidad = int.Parse(txtcantidad.Text); no hay
            for (int i = 0; i < gvDetalleSolicitud.Rows.Count; i++)
            {
                string importetotal = gvDetalleSolicitud.Rows[i].Cells[3].Text;
                dtoSolicitud.DS_ImporteTotal = Convert.ToDouble(importetotal);
            }
            dtoSolicitud.DTS_FechaRecojo = Calendar1.SelectedDate;
            ctrSolicitud.RegistrarSolicitud_PExC(dtoSolicitud);
            ctrSolicitud.Actualizar_Estado_Solicitud2(dtoSolicitud);
            Response.Redirect("Administrar_Pedido.aspx");
            

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Actualizado Correctamente!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
        }
    }
}