using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using WorkerService;

namespace WorkerServiceTests;

public class WorkerServiceTests
{
    private readonly Mock<IServiceProvider> _serviceProviderMock;
    // private readonly Mock<ILogger<Worker>> _loggerMock;

    private Worker GetWorker()
    {
        var loggerMock =  new Mock<ILogger<Worker>>();
        return new Worker(loggerMock.Object);
    }
    
    [Fact]
    public void Constructor_WorkerService()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<Worker>>();
        
        // Act
        Action a = () =>
        {
            var dummy = new Worker(loggerMock.Object);
        };
        
        // Assert
        a.Should().NotThrow();
    }
    
    
    [Fact]
    public async Task WorkerService_Any_ShouldBeStopWhenCounterEqualTen()
    {
        // Arrange
        var worker = GetWorker();
        
        // Act
        worker.StartAsync(CancellationToken.None)
            .GetAwaiter()
            .GetResult();
        
        // Arrange
        // TODO: complete this test
    }
}