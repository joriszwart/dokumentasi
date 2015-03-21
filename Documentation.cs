using System;
using System.Xml.Linq;

namespace dokumentasi
{
    class Documentation
    {
        /// <summary>
        /// Print a list of identifiers from the generated documentation xml.
        /// </summary>
        public static void PrintDocumentation()
        {
            var doc = XDocument.Load("dokumentasi.xml");
            var members = doc.Descendants("member");
            foreach (var member in members)
            {
                string name = member.Attribute("name").Value;
                switch (name[0])
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
    }
}
