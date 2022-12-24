using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CTR;
using DTO;

namespace WEB
{
    public partial class Administrar_Solicitud_Pedido : System.Web.UI.Page
    {
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        CtrMoldura objctrM = new CtrMoldura();
        CtrMolduraXUsuario objCtrMXU = new CtrMolduraXUsuario();
        DtoMolduraXUsuario objDtoMXU = new DtoMolduraXUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("Administrar Solicitud Pedido", "Carga de pagina");
                try
                {
                    if (Session["DNIUsuario"] != null)
                    {
                        objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                        UpdatePanel.Update();
                        gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                        gvCarrito.DataBind();

                        if (gvCarrito.Rows.Count < 0)
                        {
                            btncrear.Visible = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("IniciarSesion.aspx");
                    }
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("Administrar Solicitud Pedido", ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvCarrito.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    objDtoMXU.PK_IMU_Cod = int.Parse(id);
                    DtoMoldura objDtoMoldura = new DtoMoldura();
                    DtoTipoMoldura dtoTipoMoldura = new DtoTipoMoldura();
                    objCtrMXU.obtenerMoldura(objDtoMXU, objDtoMoldura, dtoTipoMoldura);
                    objctrM.ObtenerMoldura(objDtoMoldura, dtoTipoMoldura);

                    _log.CustomWriteOnLog("carrito de compra", "PK_IMU_Cod" + objDtoMXU.PK_IMU_Cod.ToString());
                    _log.CustomWriteOnLog("carrito de compra", "codigoMoldura" + objDtoMoldura.PK_IM_Cod.ToString());
                    _log.CustomWriteOnLog("carrito de compra", "descripcion" + objDtoMoldura.VM_Descripcion);
                    _log.CustomWriteOnLog("carrito de compra", "tipomoldura" + dtoTipoMoldura.VTM_Nombre);
                    _log.CustomWriteOnLog("carrito de compra", "medida" + objDtoMoldura.DM_Largo.ToString());
                    _log.CustomWriteOnLog("carrito de compra", "medida" + objDtoMoldura.DM_Ancho.ToString());
                    _log.CustomWriteOnLog("carrito de compra", "unidad metrica" + dtoTipoMoldura.VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("carrito de compra", "cantidad" + objDtoMXU.PK_IMU_Cod.ToString());
                    _log.CustomWriteOnLog("carrito de compra", "precio" + objDtoMXU.DMU_Precio.ToString());

                    txtcodigoModal.Text = objDtoMXU.PK_IMU_Cod.ToString();
                    txtcodM.Text = objDtoMoldura.PK_IM_Cod.ToString();
                    txtDescripcionModal.Text = objDtoMoldura.VM_Descripcion;
                    txtprecior.Value = objDtoMoldura.DM_Precio.ToString();
                    txtTMModal.Text = dtoTipoMoldura.VTM_Nombre;
                    txtlargo.Text = objDtoMoldura.DM_Largo.ToString();
                    txtancho.Text = objDtoMoldura.DM_Ancho.ToString();
                    txtUMModal.Text = dtoTipoMoldura.VTM_UnidadMetrica;
                    txtcantidadModal.Text = objDtoMXU.IMU_Cantidad.ToString();
                    double precioU = (objDtoMXU.DMU_Precio / objDtoMXU.IMU_Cantidad);
                    txtPrecioModal.Value = objDtoMoldura.DM_Precio.ToString();
                    _log.CustomWriteOnLog("carrito de compra", "moldura" + objDtoMoldura.PK_IM_Cod);
                    _log.CustomWriteOnLog("carrito de compra", "Imagen: " + objDtoMoldura.VBM_Imagen);
                    //#region ObtenerImagen
                    //string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                    //using (SqlConnection con = new SqlConnection(cs))
                    //{
                    //    SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    SqlParameter paramId = new SqlParameter()
                    //    {
                    //        ParameterName = "@Id",
                    //        Value = objDtoMoldura.PK_IM_Cod
                    //    };
                    //    _log.CustomWriteOnLog("carrito de compra", "id" + objDtoMoldura.PK_IM_Cod);


                    //    cmd.Parameters.Add(paramId);
                    //    _log.CustomWriteOnLog("carrito de compra", "1");

                    //    con.Open();
                    //    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    //    _log.CustomWriteOnLog("carrito de compra", "2");

                    //    con.Close();
                    //    string strbase64 = Convert.ToBase64String(bytes);
                    //    _log.CustomWriteOnLog("carrito de compra", "3");

                    //    Image1.ImageUrl = "data:Image/png;base64," + strbase64;
                    //}
                    //#endregion
                    Image1.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String(objDtoMoldura.VBM_Imagen);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#defaultmodal').modal('show');</script>", false);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

                    throw;
                }
            }
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = gvCarrito.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    objDtoMXU.FK_IM_Cod = int.Parse(id);

                    _log.CustomWriteOnLog("carrito de compra", "eliminar id:" + id);
                    _log.CustomWriteOnLog("carrito de compra", "dni:" + Session["DNIUsuario"].ToString());
                    objCtrMXU.eliminarMXU(objDtoMXU);
                    objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                    UpdatePanel.Update();
                    //explotaaaaaa
                    gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                    gvCarrito.DataBind();
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);

                    throw;
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("carrito de compra", "moldura" + txtcodM.Text);
            objDtoMoldura.PK_IM_Cod = Convert.ToInt32(txtcodM.Text);
            int stock = objctrM.StockMoldura(objDtoMoldura);
            _log.CustomWriteOnLog("carrito de compra", "stock: " + stock.ToString());
            int cant = Convert.ToInt32(txtcantidadModal.Text);
            if (cant < stock)
            {
                _log.CustomWriteOnLog("carrito de compra", "stock es mayor a la cantidad");
                if (txtUMModal.Text == "Mt" && cant < 150 || txtUMModal.Text == "Cm" && cant < 30 || txtUMModal.Text == "M2" && cant < 40)
                {
                    try
                    {
                        _log.CustomWriteOnLog("carrito de compra", "Entro a funcion actualizar");
                        objDtoMXU.PK_IMU_Cod = Convert.ToInt32(txtcodigoModal.Text);
                        objDtoMXU.IMU_Cantidad = Convert.ToInt32(txtcantidadModal.Text);
                        objDtoMXU.DMU_Precio = Convert.ToDouble(txtPrecioModal.Value) * Convert.ToInt32(txtcantidadModal.Text);
                        _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.PK_IMU_Cod :" + objDtoMXU.PK_IMU_Cod.ToString());
                        _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.IMU_Cantidadr :" + objDtoMXU.IMU_Cantidad.ToString());
                        _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.DMU_Precio :" + objDtoMXU.DMU_Precio.ToString());

                        objCtrMXU.actualizarMXU(objDtoMXU);
                        _log.CustomWriteOnLog("carrito de compra", "Paso funcion :");

                        objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                        _log.CustomWriteOnLog("carrito de compra", "objDtoMXU.FK_VU_Cod :" + objDtoMXU.FK_VU_Dni);

                        UpdatePanel.Update();
                        gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                        _log.CustomWriteOnLog("carrito de compra", "listarmolduraxusuario paso");
                        Utils.AddScriptClientUpdatePanel(UpdatePanel, "showSuccessMessage2()");

                        gvCarrito.DataBind();

                    }
                    catch (Exception ex)
                    {
                        _log.CustomWriteOnLog("carrito de compra", ex.Message + "Stac" + ex.StackTrace);
                    }
                }
                else//tipo moldura baqueton
                {
                    string m = "cantidad supera el limite permitido";
                    _log.CustomWriteOnLog("carrito de compra", m);
                    mensaje.InnerText = m;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);
                }
            }
            else //supera stock
            {
                string m = "cantidad supera al stock";
                _log.CustomWriteOnLog("carrito de compra", m);
                mensaje.InnerText = m;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#confirmacionmodal').modal('show');</script>", false);
            }
        }

        protected void btnPagar_Click1(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("carrito de compra", "Entro");
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("PK_IMU_Cod"), new DataColumn("VM_Descripcion") });
                List<int> termsList = new List<int>();
                List<double> listprecio = new List<double>();

                foreach (GridViewRow row in gvCarrito.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string IdSeleccionados = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                            string IdSeleccionadosPrecio = (row.Cells[2].FindControl("lblPrecioItems") as Label).Text;
                            _log.CustomWriteOnLog("carrito de compra", "IDseleccionado:" + IdSeleccionados.ToString());
                            _log.CustomWriteOnLog("carrito de compra", "IdSeleccionadosPrecio:" + IdSeleccionadosPrecio.ToString());

                            termsList.Add(int.Parse(IdSeleccionados));
                            listprecio.Add(double.Parse(IdSeleccionadosPrecio));
                        }
                    }
                }
                double total = listprecio.Sum();
                _log.CustomWriteOnLog("carrito de compra", "Suma total de items seleccionados:" + total.ToString());

                if (termsList.Count >= 0)
                {
                    _log.CustomWriteOnLog("carrito de compra", "termsList.Count :  " + termsList.Count);
                    int ValorDevuelto;


                    objDtoSolicitud.DS_ImporteTotal = total;
                    objCtrSolicitud.RegistrarSolicitud_LD(objDtoSolicitud);
                    ValorDevuelto = objDtoSolicitud.PK_IS_Cod;


                    for (int i = 0; i < termsList.Count; i++)
                    {

                        _log.CustomWriteOnLog("carrito de compra", "Valor ID de solicitud retornado :  " + ValorDevuelto.ToString());

                        objDtoMXU.PK_IMU_Cod = termsList[i];
                        objDtoMXU.FK_IS_Cod = ValorDevuelto;
                        _log.CustomWriteOnLog("carrito de compra", "Para actualizar la moldura x usuario Id :  " + objDtoMXU.PK_IMU_Cod);
                        _log.CustomWriteOnLog("carrito de compra", "Para actualizar la moldura x usuario IdSolicitud :  " + objDtoMXU.FK_IS_Cod);

                        objCtrMXU.actualizarMXUSol(objDtoMXU);
                        _log.CustomWriteOnLog("carrito de compra", "Actualizado Id= " + termsList[i]);

                    }
                    objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                    UpdatePanel.Update();
                    gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
                    gvCarrito.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Solicitud creada correctamente!',text: 'Pulsa el botón y se te redirigirá!'}).then(function(){window.location.href='Administrar_Pedido.aspx'})", true);
                    //Utils.AddScriptClientUpdatePanel(UpdatePanel, "showCancelMessage()");
                    Response.Redirect("ConsultarEstadosPago.aspx");
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("carrito de compra", "Error : " + ex.Message + "Stac" + ex.StackTrace);

            }
        }
        protected void btnAceptarRedirigir_Click(object sender, EventArgs e)
        {
            Session["idMoldura"] = txtcodM.Text;
            //Response.Redirect("~/RealizarPedidoPersonalizado.aspx");
        }

        protected void gvCarrito_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
            gvCarrito.PageIndex = e.NewPageIndex;
            gvCarrito.DataSource = objCtrMXU.listarMoldurasxusuario(objDtoMXU);
            gvCarrito.DataBind();
        }
    }
}