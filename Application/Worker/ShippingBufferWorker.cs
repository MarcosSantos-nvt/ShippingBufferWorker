using Application.Interfaces;
using System.Diagnostics;

namespace Application.Worker
{
    public class ShippingBufferWorker : BackgroundService, IHostedService
    {
        private readonly ILogger<ShippingBufferWorker> _logger;
        private readonly IMetodoTesteAppService _metodoAppService;
        public ShippingBufferWorker(ILogger<ShippingBufferWorker> logger, IMetodoTesteAppService metodoAppService)
        {
            _logger = logger;
            _metodoAppService = metodoAppService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {     
                MetodoTesteAsync().Wait();
                await Task.Delay(900000, stoppingToken);
            }
        }

        async Task MetodoTesteAsync()
        {
            MostrarConsumoMemoria("Inicio");
            _logger.LogInformation($"{DateTime.Now} - Teste ShippingBufferWorker");
            await _metodoAppService.MetodoTaskAsync();
            _logger.LogInformation($"{DateTime.Now} - Fim processamento");
            MostrarConsumoMemoria("Fim");
        }

        void MostrarConsumoMemoria(string operacao)
        {
            Process processoAtual = Process.GetCurrentProcess();
            var memoriaUtilizada = processoAtual.PrivateMemorySize64 / 1e+6;
            var total = processoAtual.WorkingSet64 / 1e+6;

            _logger.LogInformation($"{DateTime.Now}: Memoria usada {operacao}: aplicacao: {memoriaUtilizada} Total: {total}");
        }
    }
}
