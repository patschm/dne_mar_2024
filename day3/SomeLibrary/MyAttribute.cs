
namespace SomeLibrary;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class MyAttribute : Attribute
{
    public int PrefAge { get; set; }
}
