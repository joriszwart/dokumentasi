using System;
using System.Reflection;

namespace dokumentasi
{
    class Reflection
    {
        /// <summary>
        /// Print a list of identifiers through reflection.
        /// </summary>
        public static void PrintReflection()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            Array.Sort(types, new TypeComparer());

            foreach (var type in types)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("type: " + type.GetSignature());

                var methods = type.GetMethods();
                Array.Sort(methods, new MethodInfoComparer());
                foreach (var method in methods)
                {
                    Console.WriteLine("  method: " + method.GetSignature());
                }

                var fields = type.GetFields();
                Array.Sort(fields, new FieldInfoComparer());
                foreach (var field in fields)
                {
                    Console.WriteLine("  field: " + field.Name);
                }
            }
        }
    }
}
