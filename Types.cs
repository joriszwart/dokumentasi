using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dokumentasi
{
    enum TypeType { Class, Delegate, Enum, Interface, Struct };

    static class TypeExtensions
    {
        public static string GetSignature(this Type type)
        {
            return String.Format(
                "{0}{1} {2}",
                GetModifiers(type),
                GetTypeName(type),
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

        public static string GetTypeName(this Type type)
        {
            string typename = "";

            if (type.IsPrimitive) return type.Name.ToLower();

            if (type.IsClass) typename += "class";
            if (type.IsEnum) typename += "enum";
            if (type.IsInterface) typename += "interface";
            if (type.IsArray) typename += " []";

            return typename;
        }
    }
}
