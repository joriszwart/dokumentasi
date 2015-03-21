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
}
