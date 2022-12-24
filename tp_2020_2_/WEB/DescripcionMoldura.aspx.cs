using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WEB
{
    public partial class DescripcionMoldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        CtrTipoMoldura objCtrTipoMoldura = new CtrTipoMoldura();
        DtoMoldura objDtoMoldura = new DtoMoldura();
        DtoTipoMoldura objDtoTipoMoldura = new DtoTipoMoldura();
        Log _log = new Log();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Params["Id"] != null)
                {
                    Image1.Visible = true;
                    obtenerInformacionMoldura(Request.Params["Id"]);
                }
            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("DescripcionMoldura", "Error = " + ex.Message + "Stac" + ex.StackTrace);
                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inspeccionar_Catalogo.aspx");
        }
        public void obtenerInformacionMoldura(string id)
        {
            _log.CustomWriteOnLog("PropiedadMoldura", "-------------------------------------------------- Entro a descripcion moldura ----------------------------------------");
            objDtoMoldura.PK_IM_Cod = int.Parse(id);

            objCtrMoldura.ObtenerMoldura(objDtoMoldura, objDtoTipoMoldura);
            _log.CustomWriteOnLog("DescripcionMoldura", "Valores retornados");
            _log.CustomWriteOnLog("DescripcionMoldura", "PK_IM_Cod" + objDtoMoldura.PK_IM_Cod);
            //_log.CustomWriteOnLog("DescripcionMoldura", "VTM_UnidadMetrica" + objDtoTipoMoldura.VTM_UnidadMetrica);
            _log.CustomWriteOnLog("DescripcionMoldura", "DM_Precio" + objDtoMoldura.DM_Precio);
            _log.CustomWriteOnLog("DescripcionMoldura", "VM_Descripcion" + objDtoMoldura.VM_Descripcion);
            _log.CustomWriteOnLog("DescripcionMoldura", "PK_ITM_Tipo " + objDtoTipoMoldura.PK_ITM_Tipo);
            _log.CustomWriteOnLog("DescripcionMoldura", "VTM_Nombre" + objDtoTipoMoldura.VTM_Nombre);
            _log.CustomWriteOnLog("DescripcionMoldura", "IM_Estado" + objDtoMoldura.IM_Estado);
            _log.CustomWriteOnLog("DescripcionMoldura", "IM_Stock" + objDtoMoldura.IM_Stock);

            #region ObtenerImagen
            string cs = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_GetImageById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(paramId);
                con.Open();
                byte[] ByteArray = (byte[])cmd.ExecuteScalar();
                con.Close();
                string strbase64 = Convert.ToBase64String(ByteArray);

                Image1.ImageUrl = "data:Image/png;base64," + strbase64;
            }
            #endregion

            if (objDtoMoldura.IM_Stock != 0 && objDtoMoldura.IM_Estado!=0)
            {
                lblestadostock.Text = "En stock";
                lblestadostock.Visible = true;
                lblNostock.Visible = false;
            }
            else
            {
                lblNostock.Text = "Fuera de stock";
                lblNostock.Visible = true;
                lblestadostock.Visible = false;
            }


            //txtCodigo.Text = objDtoMoldura.PK_IM_Cod.ToString();
            //ddlTipoMoldura.SelectedValue = objDtoTipoMoldura.PK_ITM_Tipo.ToString();
            //txtmetrica.Text = objDtoTipoMoldura.VTM_UnidadMetrica.ToString();
            txtprecio.Text = objDtoMoldura.DM_Precio.ToString();
            //txtStock.Text = objDtoMoldura.IM_Stock.ToString();
            //txtMedida.Text = objDtoMoldura.DM_Medida.ToString();
            //ddlEstadoMoldura.SelectedValue = objDtoMoldura.IM_Estado.ToString();
            txtlargo.Text = objDtoMoldura.DM_Largo.ToString();
            txtancho.Text = objDtoMoldura.DM_Ancho.ToString();
            txtstock.Text = objDtoMoldura.IM_Stock.ToString();
            txtcodigomoldura.Text = objDtoMoldura.PK_IM_Cod.ToString();
            txtnombre.Text = objDtoTipoMoldura.VTM_Nombre;
            txtdescripcion.Text = objDtoMoldura.VM_Descripcion;

        }
    }
}