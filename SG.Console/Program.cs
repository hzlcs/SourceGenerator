using System.Runtime.CompilerServices;

namespace SG.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine(new Sample().GetString());
        
    }

    void Fun()
    {

    }
}

public class Sample
{

    private string GetString()
    {
        return "Hello, World!";
    }

}
