using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using DTO;
using CTR;
using System.IO;

namespace WEB
{
    public partial class ReporteVentas : System.Web.UI.Page
    {
        CtrSolicitud objCtrSolicitud = new CtrSolicitud();
        DtoSolicitud objDtoSOlicitud = new DtoSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                gvVentas.DataSource = objCtrSolicitud.SolicitudesTerminadas();
                gvVentas.DataBind();
                lbltotal.Text = objCtrSolicitud.ImporteTotal().ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string fechaInicio=txtFechaInicio.Text;
            string fechaFin=txtFechaFin.Text;
            if (fechaInicio != "" && fechaFin != "")
            {
                DateTime inicio = Convert.ToDateTime(fechaInicio), fin = Convert.ToDateTime(fechaFin);

                if ( inicio <= fin)
                {
                    gvVentas.DataSource = objCtrSolicitud.SolicitudesTerminadasEntreFechas(fechaInicio, fechaFin);
                    gvVentas.DataBind();
                    lbltotal.Text = (objCtrSolicitud.ImporteTotalEntreFechas(fechaInicio, fechaFin)).ToString();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({type:'error',title:'ERROR!',text:'Espacios VACIOS o intervalo incorrecto!!'})", true);
                return;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        public override bool EnableEventValidation
        {
            get { return false; }
            set { }
        }

        protected void ExportToPDF(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvVentas.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

    }
}