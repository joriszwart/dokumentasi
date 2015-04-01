using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    public class Event
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Signature { get; set; }
        public string Description { get; set; }
    }

    class EventInfoComparer : IComparer<EventInfo>
    {
        public int Compare(EventInfo a, EventInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
}
