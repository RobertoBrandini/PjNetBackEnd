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
    /// Summary description for wsFilmes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebAPP : System.Web.Services.WebService
    {
        public WebAPP() { }

        [WebMethod(Description = "Obter todo Clima json")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterClima()
        {
            DataTable dtRet = WebFilmesNG.Clima_NG.ObterClima();
            String jsonRet = WebFilmesNG.Util.ConverterDataTableJson(dtRet);
            Context.Response.Output.Write(jsonRet);
            Context.Response.End();
            return string.Empty;
        }

        [WebMethod(Description = "Obter Climas xml")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterClimaXML()
        {
            // Atores
            DataTable dtRet = WebFilmesNG.Clima_NG.ObterClima();
            String xmlRet = WebFilmesNG.Util.ConvertDataTableXML(dtRet);
            return xmlRet;
        }
    }
}
