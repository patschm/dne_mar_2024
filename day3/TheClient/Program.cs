
using System.Reflection;

namespace TheClient;

class Program
{
    static void Main(string[] args)
    {
        //Person p = new Person {FirstName = "Henk", LastName="Peters", Age = 43};
        //p.Introduce();
        Assembly asm = Assembly.LoadFile(@"E:\Temp\SomeLibrary.dll");
        //ShowInfo(asm);
        HetBetereWerk(asm);
    }

    private static void HetBetereWerk(Assembly asm)
    {
        Type? tp = asm.GetType("SomeLibrary.Person");
        if (tp == null) return;
        object? p1 = Activator.CreateInstance(tp);

        var fProp = tp?.GetProperty("FirstName");
        fProp?.SetValue(p1, "Daantje");
        var lProp = tp?.GetProperty("LastName");
        lProp?.SetValue(p1, "Hendriks");
        var aProp = tp?.GetProperty("Age");
        aProp?.SetValue(p1, 42);

        var pField = tp?.GetField("_age", BindingFlags.Instance | BindingFlags.NonPublic);
        pField?.SetValue(p1, -42);
        
        var intro = tp?.GetMethod("Introduce");
        intro?.Invoke(p1, []);

        if (tp == null) return;
        dynamic p2 = Activator.CreateInstance(tp)!;

        p2.FirstName = "Sjakie";
        p2.LastName = "Janssen";
        p2.Age = 23;
        p2.Introduce();
        
    }

    private static void ShowInfo(Assembly asm)
    {
        System.Console.WriteLine(asm.FullName);
        foreach(Type type in asm.GetTypes())
        {
            System.Console.WriteLine(type.FullName);
            System.Console.WriteLine("===Constructors===");
            foreach(ConstructorInfo ci in type.GetConstructors())
            {
                System.Console.WriteLine(ci.Name);
            }
            System.Console.WriteLine("===Properties===");
            foreach(PropertyInfo prop in type.GetProperties())
            {
                System.Console.WriteLine(prop.Name);
            }
            System.Console.WriteLine("===Methods===");
            foreach(MethodInfo meth in type.GetMethods())
            {
                System.Console.WriteLine(meth.Name);
            }
            System.Console.WriteLine("===Fields===");
            foreach(FieldInfo fld in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic ))
            {
                System.Console.WriteLine(fld.Name);
            }
            System.Console.WriteLine("===Attributes===");
            foreach(var item in type.GetCustomAttributes())
            {
                System.Console.WriteLine(item);
            }
        }

    }
}
