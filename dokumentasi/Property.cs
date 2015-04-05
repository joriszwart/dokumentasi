using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace dokumentasi
{
    public class Property
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Signature { get; set; }
        public XElement DocumentMember { get; set; }
    }

    class PropertyInfoComparer : IComparer<PropertyInfo>
    {
        public int Compare(PropertyInfo a, PropertyInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }

    static class PropertyInfoExtensions
    {
        public static string GetSignature(this PropertyInfo property)
        {
            return property.Name;
        }
    }
}
