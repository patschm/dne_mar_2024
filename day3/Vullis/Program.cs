namespace Vullis;

class Program
{
    static Unmanaged uman1 = new Unmanaged{Id=0};
    static Unmanaged uman2 = new Unmanaged{Id=1};

    static void Main(string[] args)
    {
        try
        {
            uman1.Open();
        }
        finally
        {
            uman1.Dispose();
        }
        uman1 = null;
        //GC.Collect();
        //GC.WaitForPendingFinalizers();
        using(uman2)
        {
            uman2.Open();
        }
        uman2 = null;

        using (Unmanaged uman3 = new Unmanaged{Id=2})
        {
            uman3.Open();
        }
        Console.ReadLine();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        System.Console.WriteLine("Ending");
        Console.ReadLine();
    }
}
