
using System.Text.Json;
using System.Xml.Serialization;

namespace Cerials;


class Program
{
    static List<Person> people = new List<Person>();

    static void Main(string[] args)
    {
        GenerateData(100);

        //SerializeData(people);
        //DeserializeData();
        SerializeJsonData(people);

        //ShowData(people);
    }

    private static void DeserializeData()
    {
         var fs = File.OpenRead(@"E:\Temp\people.xml");
         var xml = new XmlSerializer(typeof(List<Person>));
         List<Person>? pers = xml.Deserialize(fs) as List<Person>;
         ShowData(pers!);
    }

    private static void SerializeData(List<Person> people)
    {
        var fs = File.OpenWrite(@"E:\Temp\people.xml");
       XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
       xml.Serialize(fs, people);
       fs.Flush();
       fs.Close();
    }

    private static void SerializeJsonData(List<Person> people)
    {
        Stream fs = File.OpenWrite(@"E:\Temp\people.json");

        var options = new JsonSerializerOptions();
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       JsonSerializer.Serialize(fs, people, options);
       
       fs.Flush();
       fs.Close();
    }
    private static void ShowData(List<Person> people)
    {
        foreach (var p in people)
        {
            System.Console.WriteLine(p);
        }
    }

    private static void GenerateData(int v)
    {
        people = new Bogus.Faker<Person>()
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Age, f => f.Random.Int(0, 123))
            .Generate(v)
            .ToList();
    }
}
