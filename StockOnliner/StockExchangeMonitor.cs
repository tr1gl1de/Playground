namespace StockOnliner;

public class StockExchangeMonitor
{
    public delegate void PriceChange(int currentPrice);
    private Thread _thread = Thread.CurrentThread;
    private bool _stateOfMonitor = false;

    public PriceChange PriceChangeHandler { get; set; }

    public StockExchangeMonitor()
    {
    }
    
    public StockExchangeMonitor(PriceChange priceChangeHandler)
    {
        PriceChangeHandler = priceChangeHandler;
    }

    public void Start()
    {
        _stateOfMonitor = true;
        _thread = new Thread(GetPrice);
        _thread.Start();
    }

    public void Stop()
    {
        _stateOfMonitor = false;
        if (_thread != Thread.CurrentThread)
        {
            _thread.Join();
        }
    }

    private void GetPrice()
    {
        while (_stateOfMonitor)
        {
            int bankOfAmericaPrice = (new Random()).Next(100);

            PriceChangeHandler(bankOfAmericaPrice);

            Thread.Sleep(500);
        }
    }
}