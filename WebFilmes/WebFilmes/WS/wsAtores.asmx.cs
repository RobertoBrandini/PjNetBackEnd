using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebFilmes.WS
{


    /// <summary>
    /// Summary description for wsAtores
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[ScriptService]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]


    [WebService(Description = "Obter todos os Atores.", Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class wsAtores : System.Web.Services.WebService
    {
        public wsAtores() {}

        [WebMethod(Description = "Obter todos os Atores")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterAtores()
        {
            // Atores
            DataTable dtAtores = WebFilmesNG.AtoresNG.ObterFilmes();
            String jsonAtores = WebFilmesNG.Util.ConverterDataTableJson(dtAtores);
            Context.Response.Output.Write(jsonAtores);
            Context.Response.End();
            return string.Empty;
            //return jsonAtores;
        }

        [WebMethod(Description = "Obter todos os Atores")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterAtoresXML()
        {
            // Atores
            DataTable dtAtores = WebFilmesNG.AtoresNG.ObterFilmes();
            String jsonAtores = WebFilmesNG.Util.ConverterDataTableJson(dtAtores);
            return jsonAtores;
        }
    }
}
