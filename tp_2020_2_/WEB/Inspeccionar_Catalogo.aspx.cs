using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using CTR;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WEB
{
    public partial class Inspeccionar_Catalogo : System.Web.UI.Page
    {
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        CtrMoldura objCtrMoldura = new CtrMoldura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //btnTodos_Click(sender,e);
                    mostrarTodos();
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("InspeccionarCatalogo ERROR", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                    throw;
                }
            }
        }
        //Muestra listado de todas las molduras con su imagen, descripcion, precio y boton detalle
        public void mostrarTodos()
        {
            DataTable dt = new DataTable();
            dt = objCtrMoldura.ListarTodoMoldura(objDtoMoldura);
            string Image1;
            string HtmlRepeater = "";
            string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            foreach (DataRow row in dt.Rows)
            {
                string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                //string DM_Medida = row["DM_Medida"].ToString();
                //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                string DM_Precio = row["DM_Precio"].ToString();
                string VTM_Nombre = row["VTM_Nombre"].ToString();
                string VM_Descripcion = row["VM_Descripcion"].ToString();

                _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = int.Parse(PK_IM_Cod)
                    };
                    _log.CustomWriteOnLog("Codigo baqueton", "id" + int.Parse(PK_IM_Cod));

                    cmd.Parameters.Add(paramId);

                    con.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    con.Close();
                    string strbase64 = Convert.ToBase64String(bytes);

                    Image1 = "data:Image/png;base64," + strbase64;
                }
                HtmlRepeater +=

                       "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                            "<div class=gal-box>" +
                                "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                    "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                               "</a>" +
                                "<div class='gall-info'>" +
                                    "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                     "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                    "<a href = javascript: void(0);>" +

                                        "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                         "<span class='text-muted ml-1'>Detalles</span>" +
                                        "</asp:button>" +

                                    "</a>" +
                                    "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                "</div>" +
                            "</div>" +
                        "</div>";


                ListaMoldura.InnerHtml = HtmlRepeater;
            }
        }
        protected void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarTodoMoldura(objDtoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo baqueton", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=

                           "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";


                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Todo moldura ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }
        //Muestra listado de molduras baqueton clasico con su imagen, descripcion, precio y boton detalle
        protected void btnBaquetonClasico_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 2;
                _log.CustomWriteOnLog("Baqueton clasico tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("InspeccionarCatalogo", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("InspeccionarCatalogo", "VTM_UnidadMetrica : " + VTM_UnidadMetrkica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id: " + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();

                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                           "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";


                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Baqueton clasico ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
            }
        }

        //Muestra listado de molduras baqueton decorado con su imagen, descripcion, precio y boton detalle
        protected void btnBaquetonDecorado_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 1;
                _log.CustomWriteOnLog("Baqueton deco tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("Baqueton", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("Baqueton", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();

                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                       "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";


                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Baqueton deco ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);

                throw;
            }
        }

        //Muestra listado de molduras Roseton clasico con su imagen, descripcion, precio y boton detalle
        protected void btnRosetonClasico_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 3;
                _log.CustomWriteOnLog("Roseton Clasic tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("BaquetonC", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                           "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Roseton Clasic ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }

        //Muestra listado de molduras Roseton decorado con su imagen, descripcion, precio y boton detalle
        protected void btnRosetonDecorado_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 4;
                _log.CustomWriteOnLog("Roseton Deco tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                             "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Roseton Deco ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }

        //Muestra listado de molduras cornisa clasica con su imagen, descripcion, precio y boton detalle
        protected void btnCornisaClasica_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 6;
                _log.CustomWriteOnLog("Cornisa clasic tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                       "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Cornisa clasic ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }

        //Muestra listado de molduras cornisa decorada con su imagen, descripcion, precio y boton detalle
        protected void btnCornisaDecorada_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 7;
                _log.CustomWriteOnLog("Cornisa deco Tipo", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;
                    }
                    HtmlRepeater +=
                        "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Cornisa Deco ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }

        //Muestra listado de molduras de placa 3D con su imagen, descripcion, precio y boton detalle
        protected void btnPlaca3D_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoTipoMoldura.PK_ITM_Tipo = 5;
                _log.CustomWriteOnLog("BaquetonC", "objDtoTipoMoldura.PK_ITM_Tipo : " + objDtoTipoMoldura.PK_ITM_Tipo);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.ListarMoldurasPaginaInicial(objDtoTipoMoldura);
                string Image1;
                string HtmlRepeater = "";
                string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

                foreach (DataRow row in dt.Rows)
                {
                    string PK_IM_Cod = row["PK_IM_Cod"].ToString();
                    //string DM_Medida = row["DM_Medida"].ToString();
                    //string VTM_UnidadMetrica = row["VTM_UnidadMetrica"].ToString();
                    string DM_Precio = row["DM_Precio"].ToString();
                    string VM_Descripcion = row["VM_Descripcion"].ToString();
                    string VTM_Nombre = row["VTM_Nombre"].ToString();

                    _log.CustomWriteOnLog("Codigo", "PK_IM_Cod : " + PK_IM_Cod);
                    //_log.CustomWriteOnLog("BaquetonC", "DM_Medida : " + DM_Medida);
                    //_log.CustomWriteOnLog("BaquetonC", "VTM_UnidadMetrica : " + VTM_UnidadMetrica);
                    _log.CustomWriteOnLog("Precio", "DM_Precio : " + DM_Precio);
                    _log.CustomWriteOnLog("Descripcion", "VM_Descripcion : " + VM_Descripcion);

                    objDtoMoldura.PK_IM_Cod = int.Parse(PK_IM_Cod);

                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramId = new SqlParameter()
                        {
                            ParameterName = "@Id",
                            Value = int.Parse(PK_IM_Cod)
                        };
                        _log.CustomWriteOnLog("Codigo", "id" + int.Parse(PK_IM_Cod));

                        cmd.Parameters.Add(paramId);

                        con.Open();
                        byte[] bytes = (byte[])cmd.ExecuteScalar();
                        con.Close();
                        string strbase64 = Convert.ToBase64String(bytes);

                        Image1 = "data:Image/png;base64," + strbase64;

                    }
                    HtmlRepeater +=
                           "<div class='col-sm-6 col-xl-3 filter-item all web illustrator'>" +
                                "<div class=gal-box>" +
                                    "<a src = '" + Image1 + "' class='image-popup' title='Baqueton-1'>" +
                                        "<img src = '" + Image1 + "' class='img-fluid' alt=Baqueton 01' width='550px' height='412px'>" +
                                   "</a>" +
                                    "<div class='gall-info'>" +
                                        "<h4 class='font-16 mt-0'>" + VTM_Nombre + " - #" + PK_IM_Cod + "</h4>" +
                                         "<h4 class='font-16 mt-0'>" + DM_Precio + "</h4>" +
                                        "<a href = javascript: void(0);>" +

                                            "<button id='btnSave' class='text-muted ml-1' onClick='cargarInformacion(" + PK_IM_Cod + ")'>" +
                                             "<span class='text-muted ml-1'>Detalles</span>" +
                                            "</asp:button>" +

                                        "</a>" +
                                        "<a href = javascript: void(0); class='gal-like-btn'><i class='mdi mdi-heart-outline text-danger'></i></a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";


                    ListaMoldura.InnerHtml = HtmlRepeater;
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("Placa 3D ERROR", "Error :" + ex.Message + "StackTrace" + ex.StackTrace);
                throw;
            }
        }
    }
}