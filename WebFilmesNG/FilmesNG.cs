using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFilmesNG
{
    public static class FilmesNG
    {
        public static DataTable ObterFilmes()
        {
            return WebFilmesAD.FilmesAD.ObterFilmes();
        }
    }
}
