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
using DAO;
using System.Configuration;

using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace WEB
{
    public partial class Realizar_Pedido_Personalizado : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        CtrTipoMoldura objctrtipomoldura = new CtrTipoMoldura();
        CtrMolduraXUsuario objCtrMXU = new CtrMolduraXUsuario();
        DtoMolduraXUsuario objDtoMXU = new DtoMolduraXUsuario();
        DtoSolicitud objDtoSolicitud = new DtoSolicitud();
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();

        Log _log = new Log();

        SqlConnection conexion = new SqlConnection(@"data source=(local); initial catalog=BD_SCPEDR; integrated security=SSPI;");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                rbCatalogo.Checked=true;
                OpcionesTipoMoldura();
                ddlTipoMoldura.SelectedValue = "1";
                _log.CustomWriteOnLog("registrar pedido personalizado", "carga datos por catalogo");

                personalizado.Visible = false;
                catalogo.Visible = Visible;
                try
                {
                    if (Session["DNIUsuario"] != null)
                    {
                        objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/IniciarSesion.aspx");
                    }
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("registrar pedido personalizado", ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        public void OpcionesTipoMoldura()
        {
            //DataSet ds = new DataSet();
            //ds = objCtrTipoMoldura.SelectTipoMoldura();
            //ddlTipoMoldura.DataSource = ds;
            //ddlTipoMoldura.DataTextField = "VTM_Nombre";
            //ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ////ddlTipoMoldura.DataBind();
            //ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            //_log.CustomWriteOnLog("registrar pedido personalizado", "Termino de llenar el ddl");


            DataSet ds = new DataSet();
            ds = objctrtipomoldura.SelectTipoMoldura();
            ddlTipoMoldura.DataSource = ds;
            ddlTipoMoldura.DataTextField = "VTM_Nombre";
            ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
            ddlTipoMoldura.DataBind();
            ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
            _log.CustomWriteOnLog("RegistrarMoldura", "Termino de llenar el ddl");
        }



        public void ObtenerMoldura()
        {
            objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "" | txtCantidad.Text == "")
            {
                Utils.AddScriptClientUpdatePanel(upBotonRegistrar, "showSuccessMessage6()");
            }


            try
            {
                //if (rbCatalogo.Checked == true)
                //{

                //REGISTRAR SOLICTUD 
                _log.CustomWriteOnLog("registrar pedido personalizado", "entro a pedido personalizado por catalogo");
                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por catalogo";
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtCantidad.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
                objDtoSolicitud.DS_Descuento = double.Parse(txtDescuento.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.DS_Descuento);
                objDtoSolicitud.DS_ImporteTotal = Convert.ToDouble(txtSubTotal.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.DS_ImporteTotal);
                objDtoSolicitud.VS_Comentario = txtComentario.Text;
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_Comentario);
                objDtoSolicitud.IS_EstadoPago = 1; //estado pendiente
                                                   //registra solicitud
                objCtrSolicitud.RegistrarSolcitud_PC(objDtoSolicitud);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la solicitud");

                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a registrar Moldura x Usuario");


                objDtoMXU.FK_IM_Cod = int.Parse(txtcodigo.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_IM_Cod);
                objDtoMXU.IMU_Cantidad = int.Parse(txtCantidad.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.IMU_Cantidad);
                objDtoMXU.DMU_Precio = Convert.ToDouble(txtSubTotal.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.DMU_Precio);
                objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_VU_Dni);
                //REGISTRAR MOLDURA X USUARIO
                objCtrMXU.registrarMXU(objDtoMXU);

                _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la Moldura x Usuario satisfactoriamente");
                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a actualizacion de la Moldura x Usuario");
                int idMXU = objDtoMXU.PK_IMU_Cod;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El idMXU es: " + idMXU);
                int Nsolicitud = objDtoSolicitud.PK_IS_Cod;
                _log.CustomWriteOnLog("registrar pedido personalizado", " El PK de solicitud guardado en Nsolicitud es: " + Nsolicitud);
                objDtoMXU.FK_IS_Cod = Nsolicitud;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El Pk de la solcitud se almacena ahora en objDtoMXU.FK_IS_Cod y es: " + objDtoMXU.FK_IS_Cod);

                //ACTUALIZAR MOLDURA X USUARIO
                objCtrMXU.actualizarMXUSol(objDtoMXU);

                //modal message
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='ConsultarEstadosPago.aspx'})", true);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se actualizado la Moldura x Usuario satisfactoriamente");
                

                //}
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultarEstadosPago.aspx");
        }

        protected void btn_BuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcodigo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Ingrese codigo de moldura!!', type: 'error'});", true);
                    return;
                }
                _log.CustomWriteOnLog("registrar pedido personalizado", "entro a busqueda");
                objDtoMoldura.PK_IM_Cod = int.Parse(txtcodigo.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMoldura.PK_IM_Cod : " + objDtoMoldura.PK_IM_Cod);
                if (!objCtrMoldura.MolduraExiste(objDtoMoldura))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!', type: 'error'});", true);

                    //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'La moldura " + objDtoMoldura.PK_IM_Cod + " NO EXISTE!!'})</script>");
                    return;
                }

                //Obtener moldura y unidad metrica

                objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
                txtDescripcion.Text = objDtoMoldura.VM_Descripcion.ToString();
                txtLargo.Text = objDtoMoldura.DM_Largo.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
                txtAncho.Text = objDtoMoldura.DM_Ancho.ToString() + objDtoTipoMoldura.VTM_UnidadMetrica.ToString();

                byte[] ByteArray = objDtoMoldura.VBM_Imagen;
                string strbase64 = Convert.ToBase64String(ByteArray);
                Imagen1.ImageUrl = "data:image/png;base64," + strbase64;

                txtunidadmetrica.Value = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
                //_log.CustomWriteOnLog("registrar pedido personalizado", " devolvio objDtoMoldura.DM_Medida y objDtoTipoMoldura.VTM_UnidadMetrica : " + objDtoMoldura.DM_Medida + " " + objDtoTipoMoldura.VTM_UnidadMetrica);
                txtPrecio.Text = objDtoMoldura.DM_Precio.ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "devolvio objDtoMoldura.DM_Precio : " + objDtoMoldura.DM_Precio);
                
                Buscar.Update();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Solicitud registrada!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='ConsultarEstadosPago.aspx'})", true);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double y = double.Parse(txtPrecio.Text);
                int cant = int.Parse(txtCantidad.Text);

                double importe = cant * y;
                if (txtunidadmetrica.Value == "Mt" && cant < 150)
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Ingrese mas de 150 unidades!!'});", true);
                    return;
                }
                if (txtunidadmetrica.Value == "Cm" && cant < 30)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Ingrese mas de 30 unidades!!'});", true);
                    return;
                }
                if (txtunidadmetrica.Value == "M2" && cant < 40)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'Ingrese mas de 40 unidades!!'});", true);
                    return;
                }




                _log.CustomWriteOnLog("registrar pedido personalizado", "valor del txtunidadmetrica" + txtunidadmetrica.Value);

                if (txtCantidad.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title: 'ERROR!',text: 'Ingresar cantidad del producto!!'});", true);

                    return;
                    //Utils.AddScriptClientUpdatePanel(Calcular1, "showSuccessMessage4()");
                }
                if (txtcodigo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title: 'ERROR!',text: 'Ingresar cantidad del producto!!'});", true);
                    return;
                }


                if (txtunidadmetrica.Value == "Mt" && cant > 149 || txtunidadmetrica.Value == "Cm" && cant > 29 || txtunidadmetrica.Value == "M2" && cant > 39)
                {

                    txtImporte.Text = Convert.ToString(importe);
                    double descuento = (importe * 5) / 100;
                    txtDescuento.Text = Convert.ToString(descuento);
                    double total = importe - descuento;
                    txtSubTotal.Text = Convert.ToString(total);

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Llene los datos correctamente!!', type: 'error'});", true);
                    //return;
                    txtImporte.Text = Convert.ToString(importe);
                }
                //calcular1.Update();



            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }
        }

        protected void btnCalcularP_Click(object sender, EventArgs e)
        {
            try
            {

                double aprox;
                if (txtCantidadP.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title: 'ERROR!',text: 'Ingresar cantidad del producto!!'});", true);
                    return;
                }
                if (ddlTipoMoldura.SelectedValue != "0")
                {
                   // objDtoTipoMoldura.PK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    aprox = objCtrMoldura.Aprox(objDtoMoldura);
                    //txtImporteAproxP.Text = Convert.ToString(objCtrMoldura.PrecioAprox(objDtoMoldura));
                    //double precio;
                    //txtImporteAproxP.Text = Convert.ToString(aprox);

                    int cantp = int.Parse(txtCantidadP.Text);
                    double a = aprox * Convert.ToDouble(cantp);
                    txtImporteAproxP.Text = Convert.ToString(a);


                    if (aprox == 0)
                    {
                        txtImporteAproxP.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'error',title: 'ERROR!',text: 'No hay tipo de moldura seleccionado!!'});", true);
                        //ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal({icon: 'error',title: 'ERROR!',text: 'No hay tipo de moldura seleccionado!!'})</script>");
                        return;
                    }
                    Calcular2.Update();

                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }
        }

        protected void btnRegistrarP_Click(object sender, EventArgs e)
        {
            try
            {
                //REGISTRAR SOLICITUD
                if (hftxtimg.Value.ToString() == "vacio")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Suba Imagen de la moldura!!'})", true);
                    return;
                }
                else if (int.Parse(ddlTipoMoldura.SelectedValue) == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Seleccione Tipo de moldura!!'})", true);
                    return;
                }

                _log.CustomWriteOnLog("registrar pedido personalizado", "La función es de creación");

                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_TipoSolicitud : " + objDtoSolicitud.VS_TipoSolicitud);
                objDtoSolicitud.VS_TipoSolicitud = "Personalizado por diseño propio";

                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.DS_Medida : " + objDtoSolicitud.DS_Largo);
                objDtoSolicitud.DS_Largo = double.Parse(txtLargoP.Text);

                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.DS_Medida : " + objDtoSolicitud.DS_Ancho);
                objDtoSolicitud.DS_Ancho = double.Parse(txtAnchoP.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.IS_Cantidad : " + objDtoSolicitud.IS_Cantidad);
                objDtoSolicitud.IS_Cantidad = int.Parse(txtCantidadP.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.DS_PrecioAprox : " + objDtoSolicitud.DS_PrecioAprox);
                objDtoSolicitud.DS_PrecioAprox = double.Parse(txtImporteAproxP.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoSolicitud.VS_Comentario : " + objDtoSolicitud.VS_Comentario);
                objDtoSolicitud.VS_Comentario = txtComentarioP.Text;
                objDtoSolicitud.IS_EstadoPago = 1; //estado pendiente
                                                   //msjeRegistrar(objDtoSolicitud);
                objCtrSolicitud.RegistrarSolcitud_PP(objDtoSolicitud);
                int ValorDevuelto = objDtoSolicitud.PK_IS_Cod;
                int NsolicitudP = objDtoSolicitud.PK_IS_Cod;

                //string cadena = hftxtimg.Value.ToString();
                //List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
                //byte[] bimagen = imagen.ToArray();


                string cadena = hftxtimg.Value.ToString();
                List<byte> imagen = Array.ConvertAll(cadena.Split(','), byte.Parse).ToList();
                byte[] bimagen = imagen.ToArray();
                objDtoSolicitud.VBS_Imagen = bimagen;
                //string cadena = hftxtimg.Value.ToString();

                objCtrMoldura.registrarImgMoldura(bimagen, NsolicitudP);

                objCtrSolicitud.registrarImgMoldura(bimagen, ValorDevuelto);


                //string cadena = hftxtimg.Value.ToString();



                //---------Utils.AddScriptClientUpdatePanel(UpdatePanel2, "uploadFileDocumentsSolicitud(" + objDtoSolicitud.PK_IS_Cod + ");");






                //Utils.AddScriptClient("showSuccessMessage2()");
                _log.CustomWriteOnLog("registrar pedido personalizado", "PK_IS_Cod valor retornado " + objDtoSolicitud.PK_IS_Cod);


                //-------------------

                //REGISTRAR MOLDURA X USUARIO
                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a registrar Moldura x Usuario");


                objDtoMXU.IMU_Cantidad = int.Parse(txtCantidadP.Text);
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.IMU_Cantidad);

                objDtoMXU.FK_VU_Dni = Session["DNIUsuario"].ToString();
                _log.CustomWriteOnLog("registrar pedido personalizado", "objDtoMXU.FK_IM_Cod : " + objDtoMXU.FK_VU_Dni);                
                objDtoMXU.FK_IM_Cod = int.Parse(ddlTipoMoldura.SelectedValue) * -1;
                objCtrMXU.registrarMXUP(objDtoMXU);
                _log.CustomWriteOnLog("registrar pedido personalizado", "se registro la Moldura x Usuario satisfactoriamente");

                //ACTUALIZAR MOLDURA X USUARIO
                _log.CustomWriteOnLog("registrar pedido personalizado", "Entra a actualizacion de la Moldura x Usuario");

                int idMXU = objDtoMXU.PK_IMU_Cod;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El idMXU es: " + idMXU);

                _log.CustomWriteOnLog("registrar pedido personalizado", " El PK de solicitud guardado en Nsolicitud es: " + NsolicitudP);

                objDtoMXU.FK_IS_Cod = NsolicitudP;
                _log.CustomWriteOnLog("registrar pedido personalizado", "El Pk de la solcitud se almacena ahora en objDtoMXU.FK_IS_Cod y es: " + objDtoMXU.FK_IS_Cod);

                objCtrMXU.actualizarMXUSolP(objDtoMXU);


                //-------------------

                _log.CustomWriteOnLog("registrar pedido personalizado", "Agregado");
                _log.CustomWriteOnLog("registrar pedido personalizado", "Completado");
                //Utils.AddScriptClientUpdatePanel(upBotonRegistrarP, "showSuccessMessage2()");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Registro Exitoso!',text: 'Datos ENVIADOS!!'}).then(function(){window.location.href='ConsultarEstadosPago.aspx'})", true);
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pedido personalizado", "Error  = " + ex.Message + "posicion" + ex.StackTrace);
            }
        }

        protected void btnRegresarP_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultarEstadosPago.aspx");
        }


        //private void msjeRegistrar(DtoSolicitud objDtoMoldura)
        //{
        //    switch (objDtoMoldura.error)
        //    {

        //        case 77:
        //            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "<script>swal('Registro Exitoso!','sOLICITUD enviada!!','success')</script>");
        //            break;
        //    }
        //}

        protected void rbCatalogo_CheckedChanged(object sender, EventArgs e)
        {
            personalizado.Visible = false;
            catalogo.Visible = true;
        }

        protected void rbDiseñoPropio_CheckedChanged(object sender, EventArgs e)
        {
            catalogo.Visible = false;
            personalizado.Visible = true;
        }
    }
}