namespace ExercisesTests.Utils;

public class TestUtils
{
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