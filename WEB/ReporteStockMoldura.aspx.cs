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
    public partial class ReporteStockMoldura : System.Web.UI.Page
    {
        CtrMoldura objCtrMoldura = new CtrMoldura();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvMolduras.DataSource = objCtrMoldura.ListarMolduras();
                gvMolduras.DataBind();
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
                    gvMolduras.RenderControl(hw);
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

        protected void gvMolduras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMolduras.PageIndex = e.NewPageIndex;
            gvMolduras.DataSource = objCtrMoldura.ListarMolduras();
            gvMolduras.DataBind();
        }
    }
}