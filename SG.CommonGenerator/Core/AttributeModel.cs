using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace SG.CommonGenerator.Core
{
    internal sealed record AttributeModel(string NameSpace, string ClassName, ImmutableArray<AttributeData> Attributes);
}
