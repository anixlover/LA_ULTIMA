using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CTR;
using DTO;
namespace WEB
{
    /// <summary>
    /// Descripción breve de ObtieneImagen
    /// </summary>
    public class ObtieneImagen : IHttpHandler
    {
        Log _Log = new Log();
        public void ProcessRequest(HttpContext context)
        {
            
            try
            {                
                CtrMoldura objCtrMoldura = new CtrMoldura();
                int id = Convert.ToInt32(context.Request.QueryString["id"]);
                DataTable dt = new DataTable();
                dt = objCtrMoldura.RetornarImagenMoldura(id);
                byte[] image = (byte[])dt.Rows[0][0];
                context.Response.ContentType = "image/jpeg";
                context.Response.ContentType = "image/jpg";
                context.Response.ContentType = "image/png";

                context.Response.BinaryWrite(image);
                context.Response.Flush();
            }
            catch (Exception ex)
            {
                _Log.CustomWriteOnLog("ObtenerImagen","Error: " + ex.Message);
                throw;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}