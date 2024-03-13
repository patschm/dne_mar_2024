
namespace Vullis;

public class Unmanaged : IDisposable
{
    private static bool _isOpen = false;
    private FileStream fs;
    private bool disposed = false;

    public int Id { get; set; }
    public void Open()
    {
        System.Console.WriteLine("Opening....");
        if (_isOpen)
        {
            System.Console.WriteLine("Helaas!!!! Al in gebruik");
            return;
        }
        _isOpen = true;
        fs = File.Create("bla.txt");
        System.Console.WriteLine("Opened");
    }
    public void Close()
    {
        System.Console.WriteLine("Closing....");
        _isOpen = false;
        System.Console.WriteLine("Closed");

    }

    private void RuimOp(bool fromFinalizer)
    {
        if (!disposed)
        {
            Close();
            if (!fromFinalizer)
            {
                fs.Dispose();
            }
            disposed = true;
        }
    }
    public void Dispose()
    {
        RuimOp(false);
        GC.SuppressFinalize(this);
    }

    ~Unmanaged()
    {
        System.Console.WriteLine($"Opruimen {Id}");
        RuimOp(true);
    }
}
