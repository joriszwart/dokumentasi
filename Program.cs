using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dokumentasi
{
    class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">command line parameters</param>
        static void Main(string[] args)
        {
            var documentation = new Documentation("dokumentasi.xml");
            Console.WriteLine("assembly: " + documentation.Assembly);
            foreach(var member in documentation.Members)
            {
                Console.WriteLine("  member: " + member.Name);
            }

            Console.WriteLine("---------------------------------");

            var assembly = Assembly.GetExecutingAssembly();
            var reflection = new Reflection(assembly);
            foreach(var type in reflection.Types)
            {
                Console.WriteLine("  type:  " + type.GetSignature());

                var methods = type.GetMethods();
                Array.Sort(methods, new MethodInfoComparer());

                var fields = type.GetFields();
                Array.Sort(fields, new FieldInfoComparer());

                foreach (var method in methods)
                {
                    Console.WriteLine("    method:  " + method.GetSignature());
                }
                foreach (var field in fields)
                {
                    Console.WriteLine("    field:  " + field.Name);
                }
            }

            if(Debugger.IsAttached)
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
