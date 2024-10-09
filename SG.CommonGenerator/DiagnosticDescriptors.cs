using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG.CommonGenerator
{
    internal class DiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor LanguageVersionNotSupported =
            new(
                "SGCG001",
                "Language version not supported",
                "The language version {0} is not supported. The minimum supported language version is {1}.",
                "Language Version",
                DiagnosticSeverity.Error,
                true
                );

    }
}
