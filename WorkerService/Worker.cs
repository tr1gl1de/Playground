namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    // private int _counter;
    public static int counter
    {
        get => counter;
        private set { }
    }

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                counter++;
                if (counter > 10)
                {
                    await StopAsync(stoppingToken);
                }

                _logger.LogInformation("Worker running at: {time}, counter:{counter}",
                    DateTimeOffset.Now, counter);
                await Task.Delay(250, stoppingToken);
            }
            
            catch (TaskCanceledException cancelEx)
            {
                _logger.LogInformation("Worker was stopped");
                return;
            }
            
            catch (Exception fatalException)
            {
                _logger.LogCritical("Worker have exception: {fatalException}", fatalException.Message);
                return;
            }
            // But i dont know it needed here ?
            finally
            {
                Dispose();
            }

        }
    }
}