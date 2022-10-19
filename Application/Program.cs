using Application.AppService;
using Application.Interfaces;
using Application.Worker;
using Havan.Inject.Grace;
using Havan.Persistence.ConnectionStrings;
using Infra.Interfaces.HTTP;
using Infra.Interfaces.Repository;
using Infra.Services.HTTP;
using Infra.Util;
using Microsoft.Data.SqlClient;
using System.Data;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true).Build();

        services.AddConnectionStringProvider();
        services.AddHavanServices();

        services.AddTransient(sp =>
               new List<IDbConnection>()
               {
                    new SqlConnection(sp.GetRequiredService<IConnectionStringProvider>().GetConnectionString("itlsys")),
                    new SqlConnection(sp.GetRequiredService<IConnectionStringProvider>().GetConnectionString("wamas_havan"))
               }
        );

        services.AddScoped<IDapperItlSys, DapperItlSys>();   
        services.AddScoped<IDapperHavanWamas, DapperHavanWamas>();
        services.AddScoped<IMetodoTesteAppService, MetodoTesteAppService>();

        services.AddHttpClient<IRequestHttpClient, RequestHttpClient>();


        services.AddHostedService<ShippingBufferWorker>();
    })
    .UseServiceProviderFactory(new GraceServiceProviderFactory())
    .Build()
    .RunAsync();




