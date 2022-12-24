using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DTO;
using CTR;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace WEB
{
    public partial class Registrar_Moldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnRemover.Visible = false;
                imgdefault.Visible = false;
                btnActualizar.Visible = false;
                txtTitulo2.Visible=false;
                Div.Visible = true;
                if (Request.Params["Id"] != null)
                {
                    txtTitulo.Text = "ACTUALIZAR LA MOLDURA ";
                    lblId.Text = Request.Params["Id"];
                    imgdefault.Visible = true;
                    btnActualizar.Visible = true;
                    btnRegistrar.Visible = false;
                    txtTitulo2.Visible = true;
                    Div.Visible = false;
                    objDtoMoldura.PK_IM_Cod = int.Parse(Request.Params["Id"]);
                    obtenerInformacionMoldura(Request.Params["Id"]);
                    btnRemover.Visible = true;
                }
                OpcionesTipoMoldura();
                ddlEstadoMoldura.SelectedValue = "1";
            }

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("RegistrarMoldura", "-------------------------------------------------------------Evento Click-----------------------");
            _log.CustomWriteOnLog("RegistrarMoldura", "Entró a evento de Registro ");
            try
            {
                if (true)
                {
                    if (txtAncho.Equals(null) | txtLargo.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete las MEDIDAS!!'})", true);
                        return;
                    }
                    else if (txtDescripcion.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte una DESCRIPCIÓN!!'})", true);
                        return;
                    }
                    else if (txtPrecio.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte un PRECIO!!'})", true);
                        return;
                    }
                    else if (txtStock.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte STOCK!!'})", true);
                        return;
                    }
                    else if (ddlEstadoMoldura.ToString()== "--Seleccione--" | ddlTipoMoldura.ToString()=="Seleccione")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Selecciones un TIPO DE MOLDURA o ESTADO!!'})", true);
                        return;
                    }
                    else if (hftxtimg.Value.ToString()== "vacio")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte una IMAGEN!!'})", true);
                        return;
                    }
                    string cadena = hftxtimg.Value.ToString();
                    List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
                    byte[] bimagen = imagen.ToArray();

                    _log.CustomWriteOnLog("RegistrarMoldura", "La función es de creación");
                    objDtoMoldura.DM_Precio = double.Parse(txtPrecio.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Precio valor ingresado " + objDtoMoldura.DM_Precio);
                    objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("RegistrarMoldura", "IM_Estado valor ingresado " + objDtoMoldura.IM_Estado);
                    objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "IM_Stock valor ingresado " + objDtoMoldura.IM_Stock);
                    objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("RegistrarMoldura", "FK_ITM_Tipo valor ingresado " + objDtoMoldura.FK_ITM_Tipo);
                    objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                    _log.CustomWriteOnLog("RegistrarMoldura", "VM_Descripcion valor ingresado " + objDtoMoldura.VM_Descripcion);
                    objDtoMoldura.DM_Largo = Double.Parse(txtLargo.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Largo valor ingresado " + objDtoMoldura.DM_Largo);
                    objDtoMoldura.DM_Ancho = Double.Parse(txtAncho.Text);
                    _log.CustomWriteOnLog("RegistrarMoldura", "DM_Ancho valor ingresado " + objDtoMoldura.DM_Ancho);
                    objCtrMoldura.InsertMoldura(objDtoMoldura);
                    int ValorDevuelto = objDtoMoldura.PK_IM_Cod;
                    _log.CustomWriteOnLog("RegistrarMoldura", "Registro exitoso de la moldura N° " + objDtoMoldura.PK_IM_Cod);

                    objCtrMoldura.registrarImgMoldura(bimagen, ValorDevuelto);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Moldura registrada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='Gestionar_Catalogo.aspx'})", true);
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("RegistrarMoldura", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
                throw;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Gestionar_Catalogo.aspx");
        }
        public void OpcionesTipoMoldura()
        {
            DataSet ds = new DataSet();
            ds = objCtrTipoMoldura.SelectTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            _log.CustomWriteOnLog("RegistrarMoldura", "Termino de llenar el ddl");
        }
        public void obtenerInformacionMoldura(string id)
        {
            _log.CustomWriteOnLog("RegistrarMoldura", "-------------------------------------------------- Entro a actualización ----------------------------------------");
            objDtoMoldura.PK_IM_Cod = int.Parse(id);
            objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);

            
            _log.CustomWriteOnLog("RegistrarMoldura", "Valores retornados");
            _log.CustomWriteOnLog("RegistrarMoldura", "PK_IM_Cod" + objDtoMoldura.PK_IM_Cod);
            _log.CustomWriteOnLog("RegistrarMoldura", "VM_Descripcion" + objDtoMoldura.VM_Descripcion);
            _log.CustomWriteOnLog("RegistrarMoldura", "PK_ITM_Tipo " + objDtoTipoMoldura.PK_ITM_Tipo);
            _log.CustomWriteOnLog("RegistrarMoldura", "VTM_Nombre" + objDtoTipoMoldura.VTM_Nombre);
            _log.CustomWriteOnLog("RegistrarMoldura", "DM_Medida" + objDtoMoldura.DM_Largo);
            _log.CustomWriteOnLog("RegistrarMoldura", "DM_Medida" + objDtoMoldura.DM_Ancho);
            _log.CustomWriteOnLog("RegistrarMoldura", "VTM_UnidadMetrica" + objDtoTipoMoldura.VTM_UnidadMetrica);
            _log.CustomWriteOnLog("RegistrarMoldura", "IM_Estado" + objDtoMoldura.IM_Estado);
            _log.CustomWriteOnLog("RegistrarMoldura", "IM_Stock" + objDtoMoldura.IM_Stock);
            _log.CustomWriteOnLog("RegistrarMoldura", "DM_Precio" + objDtoMoldura.DM_Precio);

            ddlTipoMoldura.SelectedValue = objDtoTipoMoldura.PK_ITM_Tipo.ToString();
            txtPrecio.Text = objDtoMoldura.DM_Precio.ToString();
            txtStock.Text = objDtoMoldura.IM_Stock.ToString();
            txtLargo.Text = objDtoMoldura.DM_Largo.ToString();
            txtAncho.Text = objDtoMoldura.DM_Ancho.ToString();
            ddlEstadoMoldura.SelectedValue = objDtoMoldura.IM_Estado.ToString();
            txtDescripcion.Text = objDtoMoldura.VM_Descripcion;
            byte[] ByteArray = objDtoMoldura.VBM_Imagen;
            string strbase64 = Convert.ToBase64String(ByteArray);
            imgdefault.ImageUrl = "data:image/png;base64," + strbase64;
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            imgdefault.Visible = false;
            btnRemover.Visible = false;
            txtTitulo2.Visible = false;
            Div.Visible = true;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (true)
                {
                    int ValorDevuelto = int.Parse(lblId.Text);
                    if (txtAncho.Equals(null) | txtLargo.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Complete las MEDIDAS!!'})", true);
                        return;
                    }
                    else if (txtDescripcion.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte una DESCRIPCIÓN!!'})", true);
                        return;
                    }
                    else if (txtPrecio.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte un PRECIO!!'})", true);
                        return;
                    }
                    else if (txtStock.Equals(null))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Inserte STOCK!!'})", true);
                        return;
                    }
                    else if (ddlEstadoMoldura.ToString() == "--Seleccione--" | ddlTipoMoldura.ToString() == "Seleccione")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Selecciones un TIPO DE MOLDURA o ESTADO!!'})", true);
                        return;
                    }
                    _log.CustomWriteOnLog("ActualizarMoldura", "La función es de creación");
                    objDtoMoldura.PK_IM_Cod = ValorDevuelto;
                    _log.CustomWriteOnLog("ActualizarMoldura", "PK_IM_Cod valor ingresado " + objDtoMoldura.PK_IM_Cod);
                    objDtoMoldura.DM_Precio = double.Parse(txtPrecio.Text);
                    _log.CustomWriteOnLog("ActualizarMoldura", "DM_Precio valor ingresado " + objDtoMoldura.DM_Precio);
                    objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("ActualizarMoldura", "IM_Estado valor ingresado " + objDtoMoldura.IM_Estado);
                    objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                    _log.CustomWriteOnLog("ActualizarMoldura", "IM_Stock valor ingresado " + objDtoMoldura.IM_Stock);
                    objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    _log.CustomWriteOnLog("ActualizarMoldura", "FK_ITM_Tipo valor ingresado " + objDtoMoldura.FK_ITM_Tipo);
                    objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                    _log.CustomWriteOnLog("ActualizarMoldura", "VM_Descripcion valor ingresado " + objDtoMoldura.VM_Descripcion);
                    objDtoMoldura.DM_Largo = Double.Parse(txtLargo.Text);
                    _log.CustomWriteOnLog("ActualizarMoldura", "DM_Largo valor ingresado " + objDtoMoldura.DM_Largo);
                    objDtoMoldura.DM_Ancho = Double.Parse(txtAncho.Text);
                    _log.CustomWriteOnLog("ActualizarMoldura", "DM_Ancho valor ingresado " + objDtoMoldura.DM_Ancho);
                    objCtrMoldura.ActulizarMoldura(objDtoMoldura);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Moldura Actualizada!',text: 'Datos MODIFICADOS!!'}).then(function(){window.location.href='Gestionar_Catalogo.aspx'})", true);
                    if (hftxtimg.Value.ToString() != "vacio")
                    {
                        string cadena = hftxtimg.Value.ToString();
                        List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
                        byte[] bimagen = imagen.ToArray();
                        objDtoMoldura.VBM_Imagen = bimagen;
                        objCtrMoldura.registrarImgMoldura(bimagen, ValorDevuelto);
                    } 
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("ActualizarMoldura", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
                throw;
            }
        }
    }
}