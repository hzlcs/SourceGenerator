using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG.CommonGenerator.Core
{
    internal class UnsafeAccesstorDescriptor
    {
        private static readonly Dictionary<INamedTypeSymbol, UnsafeAccesstorDescriptor> caches = [];

        public List<AttributeData> Attributes = [];

        private UnsafeAccesstorDescriptor(INamedTypeSymbol namedTypeSymbol)
        {
            Namespace = namedTypeSymbol.ContainingNamespace.ToDisplayString();
            ClassName = namedTypeSymbol.Name;
        }

        public string Namespace { get; }
        public string ClassName { get; }

        public static UnsafeAccesstorDescriptor AddUnsafeAccesstorDescriptor(INamedTypeSymbol namedTypeSymbol, IEnumerable<AttributeData> attributeDatas)
        {
            if (!caches.TryGetValue(namedTypeSymbol, out var descriptor))          
                descriptor = new UnsafeAccesstorDescriptor(namedTypeSymbol);
            descriptor.Attributes.AddRange(attributeDatas);
            return descriptor;
        }
    }
}
