using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB
{
    public partial class GestionarEstadosPedido : System.Web.UI.Page
    {
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        DtoMolduraXUsuario objDtoMolduraxUsuario = new DtoMolduraXUsuario();
        CtrMolduraXUsuario objCtrMolduraxUsuario = new CtrMolduraXUsuario();
        CtrMXUEstado objCtrMXUEstado = new CtrMXUEstado();
        DtoMolde objDtoMolde = new DtoMolde();
        CtrMolde objCtrMolde = new CtrMolde();
        DtoMxUIncidente objDtoMXUIncidente = new DtoMxUIncidente();
        CtrMXU_Incidente objCtrMXUIncidente = new CtrMXU_Incidente();
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
                    UpdatePanel1.Update();
                    gvPedidos.DataSource= objCtrSolicitud.ListarSolicitudesTrabajdor();
                    gvPedidos.DataBind();
                    
                }
            }
        }
        protected int CantidadMolde(string id)
        {
            objDtoMolde.FK_IM_Cod = int.Parse(id);
            return objCtrMolde.CantidadMoldesxMoldura(objDtoMolde);
        }
        protected Boolean ExistenMoldes(int id,int codMXU)
        {
            objDtoMolde.FK_IM_Cod = id;
            objDtoMolduraxUsuario.PK_IMU_Cod = codMXU;
            objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
            return objCtrMolde.ExistenciaMolde(objDtoMolde)&& objCtrMolde.CantidadMoldesxMoldura(objDtoMolde)>0&&objDtoSolicitud.VS_TipoSolicitud!= "Personalizado por diseño propio"&&objDtoSolicitud.FK_ISE_Cod>=9&& objDtoSolicitud.FK_ISE_Cod <11&&objDtoMolduraxUsuario.IMU_MoldesUsados==0;
        }
        protected Boolean HayMoldesEnUso(int codMXU)
        {
            objDtoMolduraxUsuario.PK_IMU_Cod = codMXU;
            objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
            return objDtoMolduraxUsuario.IMU_MoldesUsados > 0;
        }
        protected Boolean Incidente(string estadoMXU)
        {
            return estadoMXU == "Retrazo Fabricacion" | estadoMXU == "Retraso secado";
        }
        protected Boolean Despachado(string sol)
        {
            objDtoMolduraxUsuario.FK_IS_Cod=int.Parse(sol);
            return objCtrMolduraxUsuario.CantidadMoldurasDespachadasxSolicitud(objDtoMolduraxUsuario)==1;
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
                objDtoSolicitud.PK_IS_Cod = int.Parse(id);
                objCtrSolicitud.LeerSolicitudTipo(objDtoSolicitud);
                if (objDtoSolicitud.FK_ISE_Cod >= 9)
                {
                    btnComenzar.Visible = false;
                }
                else
                {
                    btnComenzar.Visible = true;
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
                    if (objCtrSolicitud.MoldurasConMoldeSolicitud(objDtoSolicitud) == 0 | objDtoSolicitud.FK_ISE_Cod>=9)
                    {
                        btnComenzar.Visible = false;
                    }
                    else
                    { 
                        btnComenzar.Visible = true; 
                    }
                    gvPersonalizado.Visible = false;
                    gvDetalles.Visible = true;
                    objCtrSolicitud.LeerSolicitudImporte(objDtoSolicitud);
                    gvDetalles.DataSource = objCtrMolduraxUsuario.ListarMoldurasXsolicitud(objDtoMolduraxUsuario);
                    gvDetalles.DataBind();
                }
                else if (objDtoSolicitud.VS_TipoSolicitud == "Personalizado por diseño propio")
                {
                    objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
                    if (objCtrMolduraxUsuario.CantidadMoldurasDespachadasxSolicitud(objDtoMolduraxUsuario) == 1)
                    {
                        btnGuardar.Visible = true;
                    }
                    else
                    {
                        btnGuardar.Visible = false;
                    }
                    if (objCtrSolicitud.MoldurasConMoldeSolicitud(objDtoSolicitud) == 0 | objDtoSolicitud.FK_ISE_Cod >= 9)
                    {
                        btnComenzar.Visible = false;
                    }
                    else
                    { 
                        btnComenzar.Visible = true; 
                    }                    
                    gvPersonalizado.Visible = true;
                    gvDetalles.Visible = false;
                    objCtrSolicitud.leerSolicitudDiseñoPersonal(objDtoSolicitud);
                    gvPersonalizado.DataSource = objCtrSolicitud.MostrarPedidoPersonalizado(objDtoSolicitud);
                    gvPersonalizado.DataBind();
                }
            }
        }
        public int obtenerEstado(string codigo)
        {
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(codigo);
            objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
            return objDtoMolduraxUsuario.FK_IMXUE_Cod;
        }
        protected void gvDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMXUEstados = (e.Row.FindControl("ddlEstados") as DropDownList);
                ddlMXUEstados.DataSource = objCtrMXUEstado.ListarEstados();
                ddlMXUEstados.DataTextField = "VMXUE_Nombre";
                ddlMXUEstados.DataValueField = "PK_IMXUE_Cod";              
                ddlMXUEstados.DataBind();
                int idMoldura = Convert.ToInt32(e.Row.Cells[2].Text);
                objDtoMolde.FK_IM_Cod = idMoldura;                
                int idE = Convert.ToInt32(e.Row.Cells[1].Text);
                objDtoMolduraxUsuario.PK_IMU_Cod = idE;
                objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
                objDtoSolicitud.PK_IS_Cod= int.Parse(lblid.Text);
                objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);                
                e.Row.Cells[1].Visible = false;
                gvDetalles.HeaderRow.Cells[1].Visible = false;
                if (!objCtrMolde.ExistenciaMolde(objDtoMolde) | objCtrMolde.CantidadMoldesxMoldura(objDtoMolde) == 0 | objDtoMolduraxUsuario.FK_IMXUE_Cod < 6|objDtoMolduraxUsuario.FK_IMXUE_Cod==11 && objCtrMolduraxUsuario.CantidadMoldurasxSolicitud(objDtoMolduraxUsuario)>1|objDtoMolduraxUsuario.IMU_MoldesUsados==0|objDtoSolicitud.FK_ISE_Cod==11)
                {
                    ddlMXUEstados.Visible = false;
                }
                else
                {
                    ddlMXUEstados.Visible = true;
                    ddlMXUEstados.SelectedValue = (objDtoMolduraxUsuario.FK_IMXUE_Cod).ToString();
                }
            }
        }

        protected void gvPersonalizado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMXUEstados = (e.Row.FindControl("ddlEstados2") as DropDownList);
                ddlMXUEstados.DataSource = objCtrMXUEstado.ListarEstados();
                ddlMXUEstados.DataTextField = "VMXUE_Nombre";
                ddlMXUEstados.DataValueField = "PK_IMXUE_Cod";
                ddlMXUEstados.DataBind();
                int idE = Convert.ToInt32(e.Row.Cells[1].Text);
                objDtoMolduraxUsuario.PK_IMU_Cod = idE;
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
                ddlMXUEstados.SelectedValue = (objDtoMolduraxUsuario.FK_IMXUE_Cod).ToString();
                e.Row.Cells[1].Visible = false;
                gvPersonalizado.HeaderRow.Cells[1].Visible = false;
                objDtoMolduraxUsuario.PK_IMU_Cod = idE;
                objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
                objDtoSolicitud.PK_IS_Cod = int.Parse(lblid.Text);
                objCtrSolicitud.leerSolicitudTipo(objDtoSolicitud);
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
                e.Row.Cells[1].Visible = false;
                if (objDtoMolduraxUsuario.FK_IMXUE_Cod < 6 | objDtoMolduraxUsuario.FK_IMXUE_Cod == 11 && objCtrMolduraxUsuario.CantidadMoldurasxSolicitud(objDtoMolduraxUsuario) > 1 | objDtoSolicitud.FK_ISE_Cod == 11)
                {
                    ddlMXUEstados.Visible = false;
                }
                else
                {
                    ddlMXUEstados.Visible = true;
                    ddlMXUEstados.SelectedValue = (objDtoMolduraxUsuario.FK_IMXUE_Cod).ToString();
                }
            }
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlEstados = (DropDownList)sender;
            string rowNumber = gvDetalles.DataKeys[gvr.RowIndex].Value.ToString();
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(rowNumber);
            objDtoMolduraxUsuario.FK_IMXUE_Cod = int.Parse(ddlEstados.SelectedValue);
            objCtrMolduraxUsuario.actualizarMXUxCod(objDtoMolduraxUsuario);
            string sol = lblid.Text;
            CargarMolduras(sol);
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
            UpdatePanel1.Update();
        }

        protected void ddlEstados2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            DropDownList ddlEstados2 = (DropDownList)sender;
            string rowNumber = gvPersonalizado.DataKeys[gvr.RowIndex].Value.ToString();
            objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(rowNumber);
            objDtoMolduraxUsuario.FK_IMXUE_Cod = int.Parse(ddlEstados2.SelectedValue);
            objCtrMolduraxUsuario.actualizarMXUxCod(objDtoMolduraxUsuario);
            string sol = lblid.Text;
            CargarMolduras(sol);
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
            UpdatePanel1.Update();
        }

        protected void gvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "Asignar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDetalles.Rows[index];
                string id = row.Cells[2].Text;
                objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(row.Cells[1].Text);
                lblIdMoldura.Text = id;
            }
            if (e.CommandName == "Devolver")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDetalles.Rows[index];
                string moldura = row.Cells[2].Text;
                string sol = lblid.Text;
                objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(moldura);
                objDtoMolde.FK_IM_Cod = int.Parse(moldura);
                objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(sol);
                objDtoMolde.IML_Cantidad = int.Parse(row.Cells[8].Text);
                objCtrMolduraxUsuario.DevolverMoldes(objDtoMolduraxUsuario);
                objCtrMolde.AumentarMoldes(objDtoMolde);
                CargarMolduras(sol);
            }
            if (e.CommandName == "Incidencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDetalles.Rows[index];
                string moldura = row.Cells[2].Text;
                lblmoldura2.Text = moldura;
                Session["Moldura"] = int.Parse(moldura);
                UpdatePanel2.Update();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            objDtoMolduraxUsuario.FK_IM_Cod = int.Parse(lblIdMoldura.Text);
            objDtoMolde.FK_IM_Cod= int.Parse(lblIdMoldura.Text);
            objDtoMolde.IML_Cantidad = int.Parse(txtCantidad.Text);
            objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
            objDtoMolduraxUsuario.IMU_MoldesUsados = int.Parse(txtCantidad.Text);
            if (int.Parse(txtCantidad.Text) <= 0 | txtCantidad.Text.Contains("e")|txtCantidad.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte un cantidad VALIDA!!'})", true);
                return;
            }
            int MoldesDisponibles= objCtrMolde.CantidadMoldesxMoldura(objDtoMolde);
            if(int.Parse(txtCantidad.Text)>= MoldesDisponibles)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Cantidad solicitada EXCEDIDA!!'})", true);
                return;
            }
            objCtrMolduraxUsuario.AgregarMoldes_a_usar(objDtoMolduraxUsuario);
            objCtrMolde.Restarmoldes(objDtoMolde);
            UpdatePanel1.Update();
            CargarMolduras(lblid.Text);
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
            txtCantidad.Text = "0";
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Moldes ASIGNADOS!',text: 'Cantidad ACTUALIZADA!!'})", true);
        }

        protected void btnComenzar_Click(object sender, EventArgs e)
        {
            objDtoSolicitud.PK_IS_Cod = int.Parse(lblid.Text);
            objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
            objCtrMolduraxUsuario.actualizarMXU_Estado_enProceso(objDtoMolduraxUsuario);
            objCtrSolicitud.ComenzarProceso(objDtoSolicitud);
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
            CargarMolduras(lblid.Text);
            UpdatePanel1.Update();
        }

        protected void btnAumentarDias_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtDias.Text) <= 0 | txtDias.Text.Contains("e") | txtDias.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Número de días INVALIDO!!'})", true);
                return;
            }
            else
            {
                objDtoMolduraxUsuario.FK_IM_Cod =int.Parse(Session["Moldura"].ToString());
                objDtoMolduraxUsuario.FK_IS_Cod = int.Parse(lblid.Text);
                objDtoSolicitud.PK_IS_Cod = int.Parse(lblid.Text);
                int dias = objCtrSolicitud.DiasRecojo(objDtoSolicitud);
                objCtrMolduraxUsuario.ExistenciaMXU2(objDtoMolduraxUsuario);

                objDtoMXUIncidente.FK_VMU_Dni = objDtoMolduraxUsuario.FK_VU_Dni;
                objDtoMXUIncidente.FK_IMU_Cod = objDtoMolduraxUsuario.PK_IMU_Cod;
                objDtoMXUIncidente.VMXU_Incidente = txtIncidente.Text;

                objDtoSolicitud.IS_Ndias = dias + int.Parse(txtDias.Text);
                objCtrSolicitud.ActualizarFecha_Ndias(objDtoSolicitud);
                objCtrMXUIncidente.RegistrarIncidente(objDtoMXUIncidente);

                gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
                gvPedidos.DataBind();
                UpdatePanel1.Update();
            }
        }

        protected void gvPersonalizado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Incidencia")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPersonalizado.Rows[index];
                string mxu = row.Cells[1].Text;
                objDtoMolduraxUsuario.PK_IMU_Cod = int.Parse(mxu);
                objCtrMolduraxUsuario.obtenerMXUxCodigo(objDtoMolduraxUsuario);
                Session["Moldura"] = objDtoMolduraxUsuario.FK_IM_Cod;
                UpdatePanel2.Update();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            objDtoSolicitud.PK_IS_Cod= int.Parse(lblid.Text);
            objCtrSolicitud.Terminar(objDtoSolicitud);
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
            UpdatePanel1.Update();
            CargarMolduras(lblid.Text);
            UpdatePanel2.Update();
        }

        protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPedidos.PageIndex = e.NewPageIndex;
            gvPedidos.DataSource = objCtrSolicitud.ListarSolicitudesTrabajdor();
            gvPedidos.DataBind();
        }
    }
}