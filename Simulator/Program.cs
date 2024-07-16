using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZooSimulator.Services;

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options=>
    {
        options.ServiceName = "Zoo Simulator";
    })
    .ConfigureAppConfiguration((_,config)=>
    {
        config.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);
    })
    .ConfigureServices((hostingContext,services)=>
    {
        var confoguration = hostingContext.Configuration;
        services.AddSingleton<IZooService, ZooService>();
        services.AddHostedService<WorkerService>();
    })
    .UseDefaultServiceProvider(options=>options.ValidateScopes=false)
    .Build();

host.Run();