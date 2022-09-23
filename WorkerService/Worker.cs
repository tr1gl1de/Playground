namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int counter = 0;
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
                await Task.Delay(1000, stoppingToken);
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