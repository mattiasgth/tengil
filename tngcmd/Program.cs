// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tngcmd;
using tngcmd.Data;

Console.WriteLine("tngcmd");

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, configBuilder) =>
    {
        configBuilder
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.Development.json", optional: true)
            .AddCommandLine(args);
    })
    .ConfigureServices((builder, services) =>
    {
        services.AddDbContext<TengilContext>(opt => opt.UseMySQL("server=tanner.tanto-system.se;database=tngEsaro;uid=mattias;pwd=naftalen1;"));
        services.AddScoped<InvoiceProcessor>();
    })
    .Build();

var processor = host.Services.GetRequiredService<InvoiceProcessor>();

await processor.Run();