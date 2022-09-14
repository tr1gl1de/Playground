namespace StockOnliner;

static class Program
{
    public static void Main(string[] args)
    {
        StockExchangeMonitor stockExchangeMonitor = new StockExchangeMonitor();
        // here we registry our method for delegate 
        stockExchangeMonitor.PriceChangeHandler = ShowCurrentPrice;
        stockExchangeMonitor.Start();
        Thread.Sleep(5_000);
        stockExchangeMonitor.Stop();
        Console.WriteLine("Monitor was stopped.");
    }

    private static void ShowCurrentPrice(int currentPrice)
    {
        Console.WriteLine("New price is {0}", currentPrice);
    }
}