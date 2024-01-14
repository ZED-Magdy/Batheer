using Batheer.Application.Common.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure
{
    public class QueryExecuter : IQueryExecuter
    {
        //public static IEnumerable<T> Query<T>(this IDbConnection cnn, string sql, object param = null, SqlTransaction transaction = null, bool buffered = true)
        private readonly string _connectionString;
        public QueryExecuter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, string connectionString = null)
        {
            var cs = getConnectionString(connectionString);
            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Open();
                return db.Query<T>(sql, param);
            }
        }

        public T Scalar<T>(string sql, object param = null, string connectionString = null)
        {
            var cs = getConnectionString(connectionString);
            using (IDbConnection db = new SqlConnection(cs))
            {
                db.Open();
                return db.ExecuteScalar<T>(sql, param);
            }
        }

        private string getConnectionString(string connectionString)
        {
            return connectionString == null ? _connectionString : connectionString;
        }

    }
}
