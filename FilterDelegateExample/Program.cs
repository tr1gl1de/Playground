namespace FilterDelegateExample;

/// <summary>
/// Class to define person
/// </summary>
public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public string Name { get; }
    public int Age { get; }
}


internal static class Program
{
    private delegate bool FilterDelegate(Person person);
    
    public static void Main(string[] args)
    {
        var p1 = new Person("John", 41);
        var p2 = new Person("Lex", 52);
        var p3 = new Person("Alex", 12);
        var p4 = new Person("Ken", 77);

        List<Person> persons = new List<Person>() { p1, p2, p3, p4 };
        
        DisplayPeople("Children:", persons, IsChild);
        DisplayPeople("Adults:", persons, IsAdult);
        DisplayPeople("Seniors:", persons, IsSenior);
    }

    /// <summary>
    /// A method to filter out the people you need
    /// </summary>
    /// <param name="title">Title of filter</param>
    /// <param name="persons">A list of people</param>
    /// <param name="filter">Method for filter</param>
    /// <returns>A filtered list of people on Console</returns>
    private static void DisplayPeople(string title, List<Person> persons, FilterDelegate filter)
    {
        Console.WriteLine(title);

        foreach (var person in persons)
        {
            if (filter(person))
            {
                Console.WriteLine("{0}, {1} year old", person.Name, person.Age);
            }
        }
        Console.Write(Environment.NewLine);
    }

    #region Filters

    private static bool IsChild(Person person) => person.Age < 18;

    private static bool IsAdult(Person person) => person.Age >= 18;

    private static bool IsSenior(Person person) => person.Age >= 65;
    
    #endregion
}

