using System.Diagnostics;
using System.Text;

namespace GarbageSpewer;

class Program
{
    static void Main(string[] args)
    {
        string s = "";
        StringBuilder s2 = new StringBuilder();
        Stopwatch watch = new Stopwatch();

        watch.Start();
        for(int i = 0; i < 100000; i++)
        {
            //s += i.ToString();
            s2.Append(i.ToString());
        }
        watch.Stop();
        System.Console.WriteLine(watch.Elapsed);
    }
}
