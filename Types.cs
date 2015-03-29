using System;
using System.Xml.Serialization;

namespace dokumentasi
{
    enum TypeType { Class, Delegate, Enum, Interface, Struct };

    public class TypeInfo
    {
        public string FullName { get; set; }
        public string Signature { get; set; }
        public string Summary { get; set; }

        public Class[] Inheritance { get; set; }
        [XmlAttribute]
        public string AssemblyName { get; set; }
        [XmlAttribute]
        public string AssemblyFileName { get; set; }
        [XmlAttribute]
        public string Namespace { get; set; }

        public Constructor[] Constructors { get; set; }
        public Method[] Methods { get; set; }
        public Event[] Events { get; set; }
        public Field[] Fields { get; set; }
        public string Remarks { get; set; }

        [XmlAttribute]
        public string Id { get; set; }
    }

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
