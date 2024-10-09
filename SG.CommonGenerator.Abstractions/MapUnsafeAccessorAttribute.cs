using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SG.CommonGenerator.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class MapUnsafeAccessorAttribute(Type targetType, MapUnsafeAccessorAttribute.UnsafeAccessorKind kind, string? name) : Attribute
    {
        public Type TargetType { get; } = targetType;

        public UnsafeAccessorKind Kind { get; } = kind;

        public string? Name { get; } = name;

        //
        // 摘要:
        //     Specifies the kind of target to which an System.Runtime.CompilerServices.UnsafeAccessorAttribute
        //     is providing access.
        public enum UnsafeAccessorKind
        {
            //
            // 摘要:
            //     Provide access to a constructor.
            Constructor = 0,
            //
            // 摘要:
            //     Provide access to a method.
            Method = 1,
            //
            // 摘要:
            //     Provide access to a static method.
            StaticMethod = 2,
            //
            // 摘要:
            //     Provide access to a field.
            Field = 3,
            //
            // 摘要:
            //     Provide access to a static field.
            StaticField = 4,
        }
    }

    

}

