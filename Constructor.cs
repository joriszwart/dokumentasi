using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    class ConstructorInfoComparer : IComparer<ConstructorInfo>
    {
        public int Compare(ConstructorInfo a, ConstructorInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }

    static class ConstructorInfoExtensions
    {
        public static string GetSignature(this ConstructorInfo constructor)
        {
            return String.Format(
                "{0}{1}({2})",
                GetModifiers(constructor),
                constructor.Name,
                GetParameters(constructor)
            );
        }

        public static string GetModifiers(this ConstructorInfo constructor)
        {
            string modifiers = "";

            if (constructor.IsPublic) modifiers += "public ";
            if (constructor.IsPrivate) modifiers += "private ";
            if (constructor.IsAssembly) modifiers += "internal ";
            if (constructor.IsFamily) modifiers += "protected ";
            if (constructor.IsStatic) modifiers += "static ";

            return modifiers;
        }

        public static string GetParameters(this ConstructorInfo constructor)
        {
            string parameters = "";

            string delimiter = "";
            foreach (var parameter in constructor.GetParameters())
            {
                parameters += delimiter + parameter.ParameterType.GetTypeName() + " " + parameter.Name;
                delimiter = ", ";
            }

            return parameters;
        }

    }
}
