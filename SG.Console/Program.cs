// See https://aka.ms/new-console-template for more information
using SG.CommonGenerator.Abstractions;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");


void Fun()
{

}

[MapUnsafeAccessor(typeof(Sample), MapUnsafeAccessorAttribute.UnsafeAccessorKind.Method, "GetString")]
public static partial class UnsafeAccessorExtensions;


public class Sample
{

    private string GetString()
    {
        return "Hello, World!";
    }
}