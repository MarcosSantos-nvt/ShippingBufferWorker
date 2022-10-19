using Dapper;
using Infra.Interfaces.Repository;
using System.Data;

namespace Infra.Util
{
    public class DapperItlSys : IDapperItlSys
    {
        IDbConnection _sqlConnection;

        public DapperItlSys(List<IDbConnection> dbConnection)
        {
            _sqlConnection = dbConnection.FirstOrDefault(d => d.Database.Contains("itlsys", StringComparison.OrdinalIgnoreCase));
        }

        public void InsertItlsys(string query, object parametros, int timeout = 30)
        {
            using (_sqlConnection)
            {
                _sqlConnection.Execute(query, parametros, commandTimeout: timeout);
            }
        }

        public IEnumerable<T> RunQueryItlsys<T>(string query, object parametros = null, int timeout = 30)
        {
            return _sqlConnection.Query<T>(query, parametros, commandTimeout: timeout);
        }

        public T QueryFirstOrDefaultItlsys<T>(string query, object parametros = null, int timeout = 30)
        {
            return _sqlConnection.QueryFirstOrDefault<T>(query, parametros, commandTimeout: timeout);
        }
    }
}

