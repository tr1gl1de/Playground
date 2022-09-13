namespace ExercisesTests.Utils;

public static class TestUtils
{
    /// <summary>
    /// Method for limiting the execution of method by time.
    /// </summary>
    /// <param name="timeoutIsSeconds">waiting time of seconds</param>
    /// <param name="action">Action for waiting method</param>
    /// <exception cref="Exception">exception in action method</exception>
    /// <exception cref="TimeoutException">thrown when completed timeout</exception>
    public static void CompletesIn(int timeoutIsSeconds, Action action)
    {
        var task = Task.Run(action);
        var completedInTime = Task.WaitAll(new[] { task }, TimeSpan.FromSeconds(timeoutIsSeconds));

        if (task.Exception != null)
        {
            if (task.Exception.InnerExceptions.Count == 1)
            {
                throw task.Exception.InnerExceptions[0];
            }

            throw task.Exception;
        }

        if (!completedInTime)
        {
            throw new TimeoutException($"Task didn't complete in {timeoutIsSeconds} seconds.");
        }
    }
}