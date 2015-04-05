using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace dokumentasi
{
    public class Field
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Signature { get; set; }
        public XElement DocumentationMember { get; set; }
    }

    class FieldInfoComparer : IComparer<FieldInfo>
    {
        public int Compare(FieldInfo a, FieldInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
}
