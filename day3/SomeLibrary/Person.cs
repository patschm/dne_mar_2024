namespace SomeLibrary;

[Obsolete("Beter niet meer gebruiken", false)]
[My(PrefAge = 42)]
public class Person
{
    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = value > 0 && value < 123 ? value : 0 ; }
    }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public void Introduce()
    {
        System.Console.WriteLine($"{FirstName} {LastName} ({Age})");
    }
}
