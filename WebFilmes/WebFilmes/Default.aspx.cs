using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFilmes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dtFilmes = WebFilmesNG.FilmesNG.ObterFilmes();
            //lblFilmes.Text = dtFilmes.Rows.Count.ToString();

            //// Atores
            //DataTable dtAtores = WebFilmesNG.AtoresNG.ObterFilmes();
            //lblAtores.Text = dtAtores.Rows.Count.ToString();
            atualizaGrid();
        }

        protected void btnClimaDownload_Click(object sender, EventArgs e)
        {
            DataTable dtRet = WebFilmesNG.Clima_NG.DownloadClima();
            atualizaGrid();
        }

        protected void atualizaGrid()
        {
            DataTable dtRet = WebFilmesNG.Clima_NG.ObterClima();
            gvwClima.DataSource = dtRet;
            gvwClima.DataBind();
        }

        protected void btnWebService_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ws/WebAPP.asmx");
        }

        public string ObterLogotipo(object icone)
        {
            return @"http://openweathermap.org/img/w/" + icone.ToString() + ".png";
        }
    }
}