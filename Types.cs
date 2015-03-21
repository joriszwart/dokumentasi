using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dokumentasi
{
    class TypeComparer: Comparer<Type>
    {
        public override int Compare(Type a, Type b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }

    static class TypeExtensions
    {
        public static string GetSignature(this Type type)
        {
            return String.Format(
                "{0}{1} {2}",
                GetModifiers(type),
                GetType(type),
                type.Name
            );
        }

        public static string GetModifiers(this Type type)
        {
            string modifiers = "";

            if (type.IsPublic) modifiers += "public ";
            if (type.IsSealed) modifiers += "sealed ";
            if (type.IsAbstract) modifiers += "abstract ";

            return modifiers;
        }

        public static string GetType(this Type type)
        {
            string typename = "";

            if (type.IsArray) typename += "[]";
            if (type.IsClass) typename += "class";
            if (type.IsEnum) typename += "enum";
            if (type.IsInterface) typename += "interface";

            return typename;
        }
    }
}
