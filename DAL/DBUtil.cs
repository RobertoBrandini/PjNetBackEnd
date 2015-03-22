using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBUtil
    {
        String _connectionString = @"Data source=(local);Initial Catalog=AndroidBasico; trusted_connection=no; user id=sa; password=xxxxx";
        private Dictionary<string, SqlParameter> parametros;

        public DBUtil()
        {
            this.parametros = new Dictionary<string, SqlParameter>();
        }

        public DataTable Obter<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
        }

        public Int32 Inserir<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    object retorno = cmd.ExecuteScalar();
                    return Convert.ToInt32(retorno.ToString());
                }
            }
        }

        public void AdicionarParametro(string nome, DbType tipoDado, object valor)
        {
            SqlParameter parameter = new SqlParameter();// providerFactory.CreateParameter();
            parameter.ParameterName = nome;
            parameter.DbType = tipoDado;
            //parameter.Size = tamanho;
            parameter.Value = valor;
            parametros.Remove(parameter.ParameterName);
            this.parametros.Add(parameter.ParameterName, parameter);
        }

        public int Gravar(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = sql;
                        foreach (SqlParameter parametro in this.parametros.Values)
                        {
                            if (parametro.Value == null)
                            {
                                parametro.Value = DBNull.Value;
                            }
                            else
                            {
                                // Substituíndo valores de parâmetros strings vazios por DBNUll
                                if (parametro.Value is string)
                                {
                                    string valor = (string)parametro.Value;
                                    if (valor.Trim().Length == 0)
                                    {
                                        parametro.Value = DBNull.Value;
                                    }
                                }
                                else
                                {
                                    // Substituíndo valores de parâmetros DateTime MinValue por DBNull
                                    if (parametro.Value is DateTime)
                                    {
                                        DateTime valor = (DateTime)parametro.Value;
                                        if (valor == DateTime.MinValue)
                                        {
                                            parametro.Value = DBNull.Value;
                                        }
                                    }
                                }
                            }
                        }

                        foreach (SqlParameter parametro in this.parametros.Values)
                        {
                            SqlParameter par = new SqlParameter(parametro.ParameterName, parametro.Value);
                            cmd.Parameters.Add(par);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 1;
        }

    }
}
