using Dapper;
using Infra.Interfaces.Repository;
using System.Data;

namespace Infra.Util
{
    public class DapperHavanWamas : IDapperHavanWamas
    {
        IDbConnection _sqlConnection;
        public DapperHavanWamas(List<IDbConnection> dbConnection)
        {
            _sqlConnection = dbConnection.FirstOrDefault(d => d.Database.Contains("wamas_havan", StringComparison.OrdinalIgnoreCase));
        }

        public void InsertHavanWamas(string query, object parametros, int timeout = 30)
        {
            using (_sqlConnection)
            {
                _sqlConnection.Execute(query, parametros, commandTimeout: timeout);
            }
        }

        public IEnumerable<T> RunQueryHavanWamas<T>(string query, object parametros = null, int timeout = 30)
        {
            return _sqlConnection.Query<T>(query, parametros, commandTimeout: timeout);
        }

        public T QueryFirstOrDefaultHavanWamas<T>(string query, object parametros = null, int timeout = 30)
        {
            return _sqlConnection.QueryFirstOrDefault<T>(query, parametros, commandTimeout: timeout);
        }

    }
}
