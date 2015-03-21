using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    class MethodInfoComparer: IComparer<MethodInfo>
    {
        public int Compare(MethodInfo a, MethodInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }

    static class MethodInfoExtensions
    {
        public static string GetSignature(this MethodInfo method)
        {
            return String.Format(
                "{0} {1}{2}({3})",
                GetReturnType(method),
                GetModifiers(method),
                method.Name,
                GetParameters(method)
            );
        }

        public static string GetModifiers(this MethodInfo method)
        {
            string modifiers = "";

            if (method.IsPublic) modifiers += "public ";
            if (method.IsPrivate) modifiers += "private ";
            if (method.IsAssembly) modifiers += "internal ";
            if (method.IsFamily) modifiers += "protected ";
            if (method.IsStatic) modifiers += "static ";

            return modifiers;
        }

        public static string GetParameters(this MethodInfo method)
        {
            string parameters = "";

            string delimiter = "";
            foreach(var parameter in method.GetParameters())
            {
                parameters += delimiter + parameter.ParameterType.GetTypeName() + " " + parameter.Name;
                delimiter = ", ";
            }

            return parameters;
        }

        public static string GetReturnType(this MethodInfo method)
        {
            return method.ReturnType.GetTypeName();
        }
    
    }
}
