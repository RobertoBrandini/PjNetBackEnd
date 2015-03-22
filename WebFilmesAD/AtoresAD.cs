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
    public static class AtoresAD
    {
        public static DataTable ObterAtores()
        {
            DBUtil dbUtil = new DBUtil();
            String sql = @"Select * from dbo.Atores";
            DataTable dtAtores = dbUtil.Obter<SqlConnection>(sql);
            return dtAtores;
        }
    }
}
