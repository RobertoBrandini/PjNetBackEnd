using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFilmesModel;

namespace WebFilmesAD
{
    public static class ClimaAD
    {
        public static DataTable ObterClima()
        {
            DBUtil dbUtil = new DBUtil();
            String sql = @"Select * from dbo.Clima";
            DataTable dtRet = dbUtil.Obter<SqlConnection>(sql);
            return dtRet;
        }

        public static Int32 InserirClima(Clima objClima)
        {
            DBUtil bd = new DBUtil();
            String sql = @"
delete dbo.Clima where dt = @dt;
INSERT INTO dbo.Clima
           (dt
           ,data
           ,temp_dia
           ,temp_tarde
           ,temp_noite
           ,nuvens_descricao
           ,descricao
           ,icone
           ,velocidade_vento
           ,nuvens
           ,chuva)
     VALUES
           (@dt
           ,@data
           ,@temp_dia
           ,@temp_tarde
           ,@temp_noite
           ,@nuvens_descricao
           ,@descricao
           ,@icone
           ,@velocidade_vento
           ,@nuvens
           ,@chuva)
";
            bd.AdicionarParametro("@dt", System.Data.DbType.AnsiString, objClima.dt);
            bd.AdicionarParametro("@data", System.Data.DbType.DateTime, objClima.data);
            bd.AdicionarParametro("@temp_dia", System.Data.DbType.Decimal, objClima.temp_dia);
            bd.AdicionarParametro("@temp_tarde", System.Data.DbType.Decimal, objClima.temp_tarde);
            bd.AdicionarParametro("@temp_noite", System.Data.DbType.Decimal, objClima.temp_noite);
            bd.AdicionarParametro("@nuvens_descricao", System.Data.DbType.AnsiString, objClima.nuvens_descricao);
            bd.AdicionarParametro("@descricao", System.Data.DbType.AnsiString, objClima.descricao);
            bd.AdicionarParametro("@icone", System.Data.DbType.AnsiString, objClima.icone);
            bd.AdicionarParametro("@velocidade_vento", System.Data.DbType.Decimal, objClima.velocidade_vento);
            bd.AdicionarParametro("@nuvens", System.Data.DbType.Int32, objClima.nuvens);
            bd.AdicionarParametro("@chuva", System.Data.DbType.Int32, objClima.chuva);

            //return bd.Inserir<SqlConnection>(sql);
            return bd.Gravar(sql);
        }
    }
}
