using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CTR;
using DTO;

namespace WEB
{
    /// <summary>
    /// Descripción breve de ObtenerImegenPersonalizada_2
    /// </summary>
    public class ObtenerImegenPersonalizada_2 : IHttpHandler
    {
        Log _Log = new Log();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                DtoSolicitud objDtoSolicitud = new DtoSolicitud();
                CtrSolicitud objCtrSolicitud = new CtrSolicitud();
                int id = Convert.ToInt32(context.Request.QueryString["id"]);
                objDtoSolicitud.PK_IS_Cod = id;
                DataTable dt = new DataTable();
                dt = objCtrSolicitud.RetornarImagenDiseñoPersonalizado(objDtoSolicitud);
                byte[] image = (byte[])dt.Rows[0][0];
                context.Response.ContentType = "image/jpeg";
                context.Response.ContentType = "image/jpg";
                context.Response.ContentType = "image/png";

                context.Response.BinaryWrite(image);
                context.Response.Flush();
            }
            catch (Exception ex)
            {
                _Log.CustomWriteOnLog("ObtenerImagen", "Error: " + ex.Message);
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