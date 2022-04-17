using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ECHO.MODEL.Configuration
{
    public abstract class DataBaseDAO
    {
        //private Connect _connect;
        private string _repository;

        public DataBaseDAO(Connect connect, string repository)
        {
            //_connect = connect;
            this._repository = repository;
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public IDbConnection DbConnection
        {
            get
            {
                string source = "Server=ec2-34-197-84-74.compute-1.amazonaws.com;Username=vgfookvvmxqkma;Database=dbt4pgsrg9e1pf;Port=5432;Password=53082bc76fa4769e97a7d5d8e859ddd37c21229f90197fe33bc8dc178239fecd;SSLMode =Prefer";
                return new NpgsqlConnection(source);
            }
        }

        // ? ESSE METODO VAI EXECUTAR UMA QUERY QUE RETORNA UMA LISTA DE OBJETOS DE TIPO T (TIPO GENÉRICO)
        public async Task<IEnumerable<T>> ExecuteQuery<T>(string query, object parameters)
        {
            using (IDbConnection conn = this.DbConnection)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    return await conn.QueryAsync<T>(query.ToString(), parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}Repository - Exception: {1}", _repository, ex.ToString()));
                }
            }
        }
        // ? ESSE METODO VAI EXECUTAR UMA QUERY QUE RETORNA UM UNICO OBJETO DE TIPO T (TIPO GENÉRICO)
        public async Task<T> ExecuteQuerySingle<T>(string query, object parameters)
        {
            using (IDbConnection conn = this.DbConnection)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    return await conn.QueryFirstOrDefaultAsync<T>(query, parameters);

                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}Repository - Exception: {1}", _repository, ex.ToString()));
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //? ESSE METODO VAI EXECUTAR UMA QUERY QUE NÃO RETORNA NADA (EXEMPLO: UPDATE)
        public async Task ExecuteQuery(string query, object parameters)
        {
            using (IDbConnection conn = this.DbConnection)
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    await conn.QueryAsync(query.ToString(), parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}Repository - Exception: {1}", _repository, ex.ToString()));
                }
            }
        }
    }
}
