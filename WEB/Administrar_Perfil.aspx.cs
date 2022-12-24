using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Windows.Forms;

namespace WEB
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        DtoUsuario objUsuario = new DtoUsuario();
        CtrUsuario objCtrUsuario = new CtrUsuario();
        DtoDatoFactura objDatoFactura = new DtoDatoFactura();
        CtrDatoFactura objCtrDatoFactura = new CtrDatoFactura();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                _log.CustomWriteOnLog("Administral Perfil", "Carga de pagina");

                try
                {
                    if (Session["DNIUsuario"] != null)
                    {
                        txtNombre.Text = (string)Session["NombreUsuario"];
                        txtApellidos.Text = (string)Session["ApellidosUsuario"];
                        txtCorreo.Text = (string)Session["CorreoUsuario"];
                        DateTime FechaNac = (DateTime)Session["FechaNacUsuario"];
                        txtFechaNac.Text = FechaNac.ToString("yyyy-MM-dd");

                        CargarRUCS();
                    }
                    else
                    {
                        Response.Redirect("~/IniciarSesion.aspx");
                    }
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("Administral Perfil", ex.Message + "Stac" + ex.StackTrace);
                }

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Correo = txtCorreo.Text;
            DateTime FechaNac = DateTime.Parse(txtFechaNac.Text);

            objUsuario.VU_Nombre = Nombre;
            objUsuario.VU_Apellidos = Apellidos;
            objUsuario.VU_Correo = Correo;
            objUsuario.DTU_FechaNac = FechaNac;
            objUsuario.PK_VU_Dni = Session["DNIUsuario"].ToString();
            objDatoFactura.FK_VU_Dni = Session["DNIUsuario"].ToString();
            objCtrUsuario.ActualizarDatos(objUsuario);
            EliminarRUCS();
            LEliminar.Items.Clear();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type: 'success',title: 'Excelente',text: 'Cambios guardados con éxito'});", true);
            Session["NombreUsuario"] = Nombre;
            Session["ApellidosUsuario"] = Apellidos;
            Session["CorreoUsuario"] = Correo;
            Session["FechaNacUsuario"] = FechaNac;
        }

        public void EliminarRUCS()
        {
            if (LEliminar.Items.Count != 0)
            {
                for (int i = 0; i < LEliminar.Items.Count; i++)
                {
                    objDatoFactura.VDF_Ruc = LEliminar.Items[i].Text;
                    objCtrDatoFactura.EliminarRUC(objDatoFactura);
                }
            }
        }
        public void CargarRUCS()
        {
            objDatoFactura.FK_VU_Dni = Session["DNIUsuario"].ToString();
            LRucs.DataSource = objCtrDatoFactura.ListarRucs(objDatoFactura);
            LRucs.DataValueField = "VDF_Ruc";
            LRucs.DataTextField = "VDF_Ruc";
            LRucs.DataBind();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inspeccionar_Catalogo.aspx");
        }

        protected void btnMoverDerecha_Click(object sender, EventArgs e)
        {
            LEliminar.Items.Add(LRucs.SelectedValue);
            int i = 0;
            i = LRucs.SelectedIndex;
            LRucs.Items.RemoveAt(i);
        }

        protected void btnMoverIzquierda_Click(object sender, EventArgs e)
        {
            LRucs.Items.Add(LEliminar.SelectedValue);
            int i = 0;
            i = LEliminar.SelectedIndex;
            LEliminar.Items.RemoveAt(i);
        }

        protected void btnMoverTodoDerecha_Click(object sender, EventArgs e)
        {
            while (LRucs.Items.Count != 0)
            {
                for (int i = 0; i < LRucs.Items.Count; i++)
                {
                    LEliminar.Items.Add(LRucs.Items[i]);
                    LRucs.Items.Remove(LRucs.Items[i]);
                }
            }
        }

        protected void btnMoverTTodoIzquierda_Click(object sender, EventArgs e)
        {
            while (LEliminar.Items.Count != 0)
            {
                for (int i = 0; i < LEliminar.Items.Count; i++)
                {
                    LRucs.Items.Add(LEliminar.Items[i]);
                    LEliminar.Items.Remove(LEliminar.Items[i]);
                }
            }
        }
    }
}