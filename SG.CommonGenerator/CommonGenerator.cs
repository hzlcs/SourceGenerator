using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SG.CommonGenerator.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SG.CommonGenerator
{
    [Generator(LanguageNames.CSharp)]
    public class CommonGenerator : IIncrementalGenerator
    {


        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            string MapUnsafeAccessorAttributeFullName = typeof(MapUnsafeAccessorAttribute).FullName;
            var data = context.SyntaxProvider.CreateSyntaxProvider(static (v, _) => v is ClassDeclarationSyntax,
                (n, _) => n.SemanticModel.GetDeclaredSymbol(n.Node));
            context.RegisterSourceOutput(context.CompilationProvider, (context, v) => context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("SGCG001", "title", "message", "Categroy", DiagnosticSeverity.Warning, true, null, null, MapUnsafeAccessorAttributeFullName), location: null, Array.Empty<object>())));
        }


    }


}
