using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;

namespace dokumentasi
{
    public class Method
    {
        public string Name { get; set; }
        public string Signature { get; set; }
    }

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
                "{0}{1} {2}({3})",
                GetModifiers(method),
                GetReturnType(method),
                GetName(method),
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

        public static string GetName(this MethodInfo method)
        {
            string name = method.Name;

            if(method.IsGenericMethod)
            {
                name += "<";
                string delimiter = "";
                foreach(var argument in method.GetGenericArguments())
                {
                    name += delimiter + argument.GetTypeName();
                    delimiter = ", ";
                }
                name += ">";
            }

            return name;
        }

        public static string GetParameters(this MethodInfo method)
        {
            string parameters = "";

            string delimiter = "";
            foreach(var parameter in method.GetParameters())
            {
                parameters += delimiter;
                if (parameter.ParameterType.IsByRef) parameters += "ref ";
                if (parameter.IsOut) parameters += "out ";
                parameters += parameter.ParameterType.GetTypeName() + " " + parameter.Name;
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
