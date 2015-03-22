using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFilmesAD
{
    public class FilmesAD
    {
        public static DataTable ObterFilmes()
        {
            DBUtil dbUtil = new DBUtil();
            String sql = @"Select * from dbo.filmes";
            DataTable dtFilmes = dbUtil.Obter<SqlConnection>(sql);
            return dtFilmes;
        }

    }
}
