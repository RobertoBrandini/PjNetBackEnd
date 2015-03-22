using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFilmesNG
{
    public static class AtoresNG
    {
        public static DataTable ObterFilmes()
        {
            return WebFilmesAD.AtoresAD.ObterAtores();
        }
    }
}
