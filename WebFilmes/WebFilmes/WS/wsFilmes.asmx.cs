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
    public class wsFilmes : System.Web.Services.WebService
    {
        public wsFilmes() { }

        [WebMethod(Description = "Obter todos os Filmes")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterFilmes()
        {
            // Atores
            DataTable dtFilmes = WebFilmesNG.FilmesNG.ObterFilmes();
            String jsonFilmes = WebFilmesNG.Util.ConverterDataTableJson(dtFilmes);
            Context.Response.Output.Write(jsonFilmes);
            Context.Response.End();
            return string.Empty;
            //return jsonAtores;
        }

        [WebMethod(Description = "Obter todos os Filmes")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ObterFilmesXML()
        {
            // Atores
            DataTable dtFilmes = WebFilmesNG.FilmesNG.ObterFilmes();
            String jsonFilmes = WebFilmesNG.Util.ConverterDataTableJson(dtFilmes);
            return jsonFilmes;
        }
    }
}
