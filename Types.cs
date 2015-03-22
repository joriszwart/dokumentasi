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
            var nullableType = Nullable.GetUnderlyingType(type);
            if (nullableType != null)
                return nullableType.Name + "?";

            if (!type.IsGenericType)
            {
                switch(type.Name)
                {
                    case "Boolean": return "bool";
                    case "Char": return "char";
                    case "Decimal": return "decimal";
                    case "Double": return "double";
                    case "Float": return "float";
                    case "Int16": return "short";
                    case "Int32": return "int";
                    case "Int64": return "long";
                    case "Object": return "object";
                    case "String": return "string";
                    case "Void": return "void";
                    default:
                        return string.IsNullOrWhiteSpace(type.FullName) ? type.Name : type.FullName;
                }
            }

            string typename = "<";
            string delimiter = "";
            foreach(var generictype in type.GetGenericArguments())
            {
                typename += delimiter + GetTypeName(generictype);
                delimiter = ", ";
            }
            typename += ">";
            return typename;
        }
    }
}
