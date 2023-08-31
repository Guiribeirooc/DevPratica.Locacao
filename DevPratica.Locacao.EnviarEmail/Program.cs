using DevPratica.Locacao.Comum.Modelo;
using DevPratica.Locacao.Comum.Servico;
using DevPratica.Locacao.EnviarEmail;
using DevPratica.Locacao.Modelo.DTO;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();
        services.AddSingleton<IApiToken, ApiToken>();
        services.AddSingleton<LoginResposta>();
        services.Configure<DadosBase>(hostContext.Configuration.GetSection("DadosBase"));

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
