namespace WorkerService;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services => { services.AddHostedService<Worker>(); })
            .Build();

        await host.RunAsync();
    }
}