using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Type> Types
        {
            get
            {
                var types = assembly.GetTypes();
                return (from type in types
                       orderby !type.IsInterface, !type.IsAbstract, !type.IsClass, !type.IsEnum, type.Name
                       select type).ToArray<Type>();
            }
        }
    }
}
