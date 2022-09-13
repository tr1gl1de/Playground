const int Counter = 1_000_000_000;

var x = 0;

var thread1 = new Thread(() =>
{
    for (var i = 0; i < Counter; i++)
    {
        // Thread.Sleep(100);
        // Console.WriteLine("thread1 counter is {0}", i);
        x++;
    }
});

var thread2 = new Thread(() =>
{
    for (var i = 0; i < Counter; i++)
    {
        // Thread.Sleep(100);
        // Console.CursorLeft = 30;
        // Console.WriteLine("thread2 counter is {0}", i);
        x++;
    }
});

var thread3 = new Thread(o =>
{
    for (var i = 0; i < Counter; i++)
    {
        // Thread.Sleep(100);
        // Console.CursorLeft = 30 * 2;
        // Console.WriteLine("thread3 counter is {0}", i);
        x++;
    }
});

thread1.Start();
thread2.Start();
thread3.Start();
thread1.Join();
thread2.Join();
thread3.Join();

Console.WriteLine(x);
Console.ReadKey();