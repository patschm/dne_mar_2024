
using System.IO.Compression;
using System.Text;

namespace Stromen;

class Program
{
    static void Main(string[] args)
    {
        //Directory
        //File
        //DirectoryInfo
        //FileInfo

        //BasicWrite();
        //BasicRead();
        //AdvancedWrite();
        //AdvancedRead();
        //CompressedWrite();
        CompressedRead();
    }

    private static void BasicRead()
    {
        FileStream fs = File.OpenRead(@"E:\Temp\file1.txt");
        byte[] emmertje = new byte[8];

        while(fs.Read(emmertje, 0, emmertje.Length) > 0)
        {
            string txt = Encoding.UTF8.GetString(emmertje);
            Console.Write(txt);
            Array.Clear(emmertje, 0, emmertje.Length);
        }
    }

    private static void BasicWrite()
    {
        FileInfo file = new FileInfo(@"E:\Temp\file1.txt");
        if (file.Exists)
            file.Delete();
        FileStream fs = file.Create();
        string txt = "Hello World";
        for (int i = 0; i < 1000; i++)
        {
            byte[] data = Encoding.UTF8.GetBytes($"{txt} {i}\r\n");
            fs.Write(data);
        }
        fs.Flush();
        fs.Close();
    }
    private static void AdvancedRead()
    {
        FileStream fs = File.OpenRead(@"E:\Temp\file2.txt");

        StreamReader reader = new StreamReader(fs);
        string? line;
        while((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
    private static void AdvancedWrite()
    {
        FileInfo file = new FileInfo(@"E:\Temp\file2.txt");
        if (file.Exists)
            file.Delete();
        FileStream fs = file.Create();
        StreamWriter writer = new StreamWriter(fs);

        string txt = "Hello World";
        for (int i = 0; i < 1000; i++)
        {
            writer.WriteLine($"{txt} {i}");
        }
        writer.Flush();
        fs.Flush();
        fs.Close();
    }
    private static void CompressedRead()
    {
        FileStream fs = File.OpenRead(@"E:\Temp\file2.zip");
        GZipStream zipper = new GZipStream(fs, CompressionMode.Decompress);

        StreamReader reader = new StreamReader(zipper);
        string? line;
        while((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
    private static void CompressedWrite()
    {
        FileInfo file = new FileInfo(@"E:\Temp\file2.zip");
        if (file.Exists)
            file.Delete();
        FileStream fs = file.Create();
        GZipStream zipper = new GZipStream(fs, CompressionMode.Compress);
        StreamWriter writer = new StreamWriter(zipper);

        string txt = "Hello World";
        for (int i = 0; i < 1000; i++)
        {
            writer.WriteLine($"{txt} {i}");
        }
        writer.Flush();
        fs.Flush();
        fs.Close();
    }
}
