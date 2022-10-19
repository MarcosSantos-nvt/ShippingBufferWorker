namespace Infra.Interfaces.Repository
{
    public interface IDapperHavanWamas
    {
        IEnumerable<T> RunQueryHavanWamas<T>(string query, object parametros = null, int timeout = 30);
        T QueryFirstOrDefaultHavanWamas<T>(string query, object parametros = null, int timeout = 30);
        void InsertHavanWamas(string query, object parametros, int timeout = 30);
    }
}
