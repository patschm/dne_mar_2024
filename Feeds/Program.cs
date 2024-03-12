using Feeds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://nu.nl/");
        var result = client.GetAsync("rss").Result;
        if (result.IsSuccessStatusCode)
        {
            var stream = result.Content.ReadAsStream();
            var strategy = new XmlSerializerStrategy();
            //var strategy = new LinqToXmlStrategy();
            //var strategy = new RegexpStrategy();
            
            foreach(var item in strategy.Process(stream))
            {
                ShowItem(item);
            }
        }
        Console.ReadLine();
    }

    public static void ShowItem(Item item)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine(item.Category);
        Console.ResetColor();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(item.Title);
        Console.ResetColor();
        Console.WriteLine(item.Description);
        Console.WriteLine();
    }
}

