// See https://aka.ms/new-console-template for more information
namespace SG.Console;
using SG.CommonGenerator.Abstractions;
using System.ComponentModel;

[MapUnsafeAccessor(typeof(Sample), MapUnsafeAccessorAttribute.UnsafeAccessorKind.Method, "GetString")]
[Description("Sample class")]
public static partial class UnsafeAccessorExtensions;

