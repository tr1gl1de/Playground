using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrExample;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        var mediator = BuildMediator();
        Console.WriteLine(await mediator.Send(new Ping()));
    }

    private static IMediator BuildMediator()
    {
        var services = new ServiceCollection()
            .AddMediatR(typeof(Program).Assembly);

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IMediator>();
    }
}

internal record Ping : IRequest<string> {}

internal class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}