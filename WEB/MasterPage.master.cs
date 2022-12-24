using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Log Log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
            Log.WriteOnLog("-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
            Log.WriteOnLog("-------------------------------------------------------------------------------------------------------------");
            int perfil = int.Parse(Session["id_perfil"].ToString());

            switch (perfil)
            {
                case 2://gerente
                    perfilGerente();
                    break;
                case 3://vendedor
                    perfilVendedor();
                    break;
                case 4://trabajador
                    perfilTrabajador();
                    break;
              
                default:
                    Session.Clear();
                    Session.Abandon();
                    HttpContext.Current.Session.Abandon();
                    Session.RemoveAll();
                    Response.Redirect("~/Login.aspx");
                    break;

            }
        }
        catch (Exception ex)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

    }
    public void perfilGerente()
    {
        string html = string.Format(@"
            <li class='active'>
                        <a href='GestionCatalogo.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Gestionar Catalago</span>
                        </a>
                    </li>
            <li>
                        <a href='Evaluar_Pedido_Personalizado.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Evaluar Pedido Personalizado</span>
                        </a>
                    </li>
        ");
        this.Literal1.Text = html;
    }
    public void perfilVendedor()
    {
        string html = string.Format(@"
            <li class='active'>
                        <a href='RegistrarClienteVendedor.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Registrar Usuario</span>
                        </a>
                    </li>
            <li>
                        <a href='RealizarVenta_Marcial.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Realizar Venta</span>
                        </a>
                    </li>
            <li>
                        <a href='AdministrarPedidos.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Administrar Pedidos</span>
                        </a>
                    </li>
        ");
        this.Literal1.Text = html;
    }
    public void perfilTrabajador()
    {
        string html = string.Format(@"
            <li class='active'>
                        <a href='Gestionar_Estado_Pedido.aspx' >
                            <i class='material-icons'>check</i>
                            <span>Gestionar Estado Pedido</span>
                        </a>
                    </li>
          
        ");
        this.Literal1.Text = html;
    }
    protected void UsuarioOption_ServerClick(object sender, EventArgs e)
    {

    }

    protected void AdministradorOption_ServerClick(object sender, EventArgs e)
    {

    }

    protected void btnCerrarSesion_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
