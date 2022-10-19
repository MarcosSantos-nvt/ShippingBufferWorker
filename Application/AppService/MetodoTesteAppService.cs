using Application.Interfaces;
using Infra.Dtos;
using Infra.Interfaces.HTTP;
using Infra.Interfaces.Repository;

namespace Application.AppService
{
    //CLASSE TESTE PARA SUBIR PRIMEIRA VERSÃO DO WORKER FAVOR EXCLUIR
    public class MetodoTesteAppService : IMetodoTesteAppService
    {
        private readonly ILogger<MetodoTesteAppService> _logger;
        private readonly IRequestHttpClient _requestHttpClient;
        public MetodoTesteAppService(ILogger<MetodoTesteAppService> logger, IRequestHttpClient requestHttpClient)
        {
            _logger = logger;
            _requestHttpClient = requestHttpClient;
        }

        public async Task MetodoTaskAsync()
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now}: iniciando Teste.");
                string url = "http://localhost:61037/motorista/validar-telefone?dddMotorista=11&telefoneMotorista=945741566";
                string token = null;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Erro no teste do Worker.");
            }
            
        }
    }
}
