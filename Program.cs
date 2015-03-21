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
        /// Print a list of identifiers from the generated documentation xml.
        /// </summary>
        private void PrintDocumentation()
        {
            var doc = XDocument.Load("dokumentasi.xml");
            var members = doc.Descendants("member");
            foreach(var member in members)
            {
                string name = member.Attribute("name").Value;
                switch(name[0])
                {
                    case 'E':
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("event: ");
                        break;

                    case 'F':
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("field: ");
                        break;

                    case 'M':
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("member: ");
                        break;

                    case 'N':
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("namespace: ");
                        break;

                    case 'P':
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("property: ");
                        break;

                    case 'T':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("class/interface/struct/enum/delegate: ");
                        break;

                    case '!':
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("resolve error: ");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("unknown: ");
                        break;
                }
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Print a list of identifiers through reflection.
        /// </summary>
        private void PrintReflection()
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach(var identifier in assembly.GetTypes())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("type: " + identifier.Namespace + " " + identifier.Name);

                var methods = identifier.GetMethods();
                Array.Sort(methods, new MethodInfoComparer());
                foreach(var method in methods)
                {
                    Console.WriteLine("  method: " + method.Name);
                }

                var fields = identifier.GetFields();
                Array.Sort(fields, new FieldInfoComparer());
                foreach (var field in fields)
                {
                    Console.WriteLine("  field: " + field.Name);
                }
            }
        }

        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">command line parameters</param>
        static void Main(string[] args)
        {
            var program = new Program();
            program.PrintDocumentation();
            Console.WriteLine("---------------------------------");
            program.PrintReflection();
            Console.ResetColor();

            if(Debugger.IsAttached)
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
