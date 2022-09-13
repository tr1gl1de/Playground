using System.Text;

namespace DelegateAndEventPlaygr;

public static class Program
{
    
    #region DelegatesWithoutReturn

    private delegate void WithStringParameter(string message);

    private static void DelegateWithOneParamExample()
    {
        WithStringParameter withStringParameter = new(ShowMessage);
        withStringParameter += ShowMessage;
        withStringParameter("new some message");
        Console.WriteLine();
        withStringParameter += ShowMessage;
        withStringParameter += ShowMessage;
        withStringParameter("one more some method");
        Console.WriteLine();
        withStringParameter -= ShowMessage;
        withStringParameter("remove one method");
    }


    #endregion

    #region DelegateWithArgAndReturn

    private delegate string WithParamAndReturn(string text1, string text2);

    private static void DelegateWithParamAndReturnExample()
    {
        WithParamAndReturn withParamAndReturn = new(ShowMessage);

        string value = withParamAndReturn("Max", "John");
        withParamAndReturn("Lex", "Ken");
    }

    #endregion

    #region DelegateWithArgHowParam

    private delegate void WithArgHowParam(params string[] strings);

    private static void DelegateWithArgHowParamExample()
    {
        WithArgHowParam argHowParam = new(ShowMessage);

        argHowParam("Max", "John", "Lex", "Jim","Alex");
    }

    #endregion

    #region MulticastDelegate

    private delegate void Multicast();

    private static void MulticastDelegateExample()
    {
        Multicast multicastDelegate = new(ShowMessage1);
        multicastDelegate += ShowMessage2;
        multicastDelegate += ShowMessage1;
        multicastDelegate += ShowMessage1;
        multicastDelegate();
        Console.WriteLine();
        multicastDelegate -= ShowMessage1;
        multicastDelegate();
    }

    #endregion

    #region DelegateWithAnynymousMethod

    private delegate void DelegateWithAnonymousMethod();

    private static void DelegateWithAnonymousMethodExample()
    {
        DelegateWithAnonymousMethod delegateWithAnonymousMethod = delegate
        {
            Console.WriteLine("Have fun!");
        };

        delegateWithAnonymousMethod();
    }

    #endregion

    #region PassingDelegateInMethodHowArgument

    private delegate void TestDelegate();

    private static void PassingDelegateInMethodHowArgumentExample()
    {
        TestDelegate testDelegate = delegate
        {
            Console.WriteLine("Nice to meet you!");
        };
        
        TestMethod(testDelegate);
    }

    private static void TestMethod(TestDelegate testDelegate)
    {
        testDelegate();
    }

    #endregion
    
    public static void Main(string[] args)
    {
        // DelegateWithParamAndReturn();
        // DelegateWithArgHowParam();
        // MulticastDelegateExample();
        // DelegateWithAnonymousMethodExample();
        PassingDelegateInMethodHowArgumentExample();
    }
    
    private static void ShowMessage(params string[] strings)
    {
        var stringBuilder = new StringBuilder();
        foreach (var s in strings)
        {
            if (!s.Equals(strings[^1]))
            {
                stringBuilder.Append($"{s} and ");
                continue;
            }

            stringBuilder.Append($"{s} have fun!");
        }

        var resultString = stringBuilder.ToString();
        Console.WriteLine(resultString);
    }

    private static string ShowMessage(string name1, string name2)
    {
        Console.WriteLine("{0} and {1} have fun!", name1, name2);
        return "some text";
    }
    
    private static void ShowMessage() 
        => Console.WriteLine("Hello");

    private static void ShowMessage(string message) 
        => Console.WriteLine(message);

    private static void ShowMessage1() => Console.WriteLine("Hello");

    private static void ShowMessage2() => Console.WriteLine("Bye");
}