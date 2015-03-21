using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    class Reflection
    {
        Assembly assembly;

        public Reflection(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IList<Type> Types
        {
            get
            {
                var types = assembly.GetTypes();
                Array.Sort(types, new TypeComparer());

                return types;
            }
        }
    }
}
