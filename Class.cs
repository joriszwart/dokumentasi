using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dokumentasi
{
    public class Class
    {
        [XmlAttribute]
        public string Name { get; set; }

        public string Signature { get; set; }

        public Class[] Descendants { get; set; }
    }

    class ClassComparer : IComparer<Class>
    {
        public int Compare(Class a, Class b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }

    public static class ClassExtensions
    {
        public static Class[] GetClassHierarchy(this Type type)
        {
            // List, Add to list, ToArray(), Array.Reverse()

            // base classes
            var typenames = new List<Class>();
            var thistype = type;
            do
            {
                typenames.Add(new Class { Name = thistype.FullName });
                thistype = thistype.BaseType;
            } while (thistype != null);

            var classes = typenames.ToArray<Class>();
            Array.Reverse(classes);

            // add direct descendants
            var descendants = from t in type.Assembly.GetTypes()
                              where t.BaseType == type
                              select t;

            var childs = new List<Class>();
            foreach (var descendant in descendants)
            {
                childs.Add(new Class { Name = descendant.FullName, Signature = descendant.GetSignature() });
            }
            var descendants2 = childs.ToArray<Class>();
            Array.Sort(descendants2, new ClassComparer());
            var last = classes.Last();

            return descendants2;
        }
    }
}