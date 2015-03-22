using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    class EventInfoComparer : IComparer<EventInfo>
    {
        public int Compare(EventInfo a, EventInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
}
