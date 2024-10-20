using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using SG.CommonGenerator.Abstractions;
using SG.CommonGenerator.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SG.CommonGenerator.Generator
{
    [Generator(LanguageNames.CSharp)]
    public class CommonGenerator : IIncrementalGenerator
    {


        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //Debugger.Launch();
            //get CultureInfo


            string MapUnsafeAccessorAttributeFullName = typeof(MapUnsafeAccessorAttribute).FullName;
            var classes = context.SyntaxProvider.ForAttributeWithMetadataName(MapUnsafeAccessorAttributeFullName,
                static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
                static (context, _) => UnsafeAccesstorDescriptor.AddUnsafeAccesstorDescriptor((INamedTypeSymbol)context.TargetSymbol, context.Attributes));

            context.RegisterSourceOutput(classes, (context, descriptor) =>
            {

                StringBuilder sb = new();
                foreach (var attribute in descriptor.Attributes)
                {
                    
                    string type = attribute.ConstructorArguments[0].Value!.ToString();
                    string arguement = type[(type.LastIndexOf('.') + 1)..];

                    string kind = ((MapUnsafeAccessorAttribute.UnsafeAccessorKind)attribute.ConstructorArguments[1].Value!).ToString(); 
                    string name = attribute.ConstructorArguments[2].Value!.ToString();
                    string member = $"""
                            [UnsafeAccessor(UnsafeAccessorKind.{kind}, Name = "{name}")]
                            public static extern string {name}(this {type} {char.ToLower(arguement[0]) + arguement[1..]});

                    """;
                    sb.AppendLine(member);
                }
                string classSource = $$"""
                using System.Runtime.CompilerServices;
                namespace {{descriptor.Namespace}}
                {
                    partial class {{descriptor.ClassName}}
                    {
                {{sb}}        
                    }
                };
                """;
                
                context.AddSource(descriptor.ClassName + ".g.cs", SourceText.From(classSource, Encoding.UTF8));
            });
        }


    }


}
