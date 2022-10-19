namespace Infra.Interfaces.Repository
{
    public interface IDapperItlSys
    {
        IEnumerable<T> RunQueryItlsys<T>(string query, object parametros = null, int timeout = 30);
        T QueryFirstOrDefaultItlsys<T>(string query, object parametros = null, int timeout = 30);
        void InsertItlsys(string query, object parametros, int timeout = 30);
    }
}
