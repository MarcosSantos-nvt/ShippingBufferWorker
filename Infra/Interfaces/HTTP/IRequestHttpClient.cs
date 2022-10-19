using Infra.Dtos;

namespace Infra.Interfaces.HTTP
{
    public interface IRequestHttpClient
    {
        Task<ResultadoBase<T>> PostAsync<T>(string url, object obj, string token = null);
        Task<ResultadoBase<T>> GetAsync<T>(string url, string token = null);
    }
}
