using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

            // table of contents
            string filename = assembly.GetName().Name + ".html";
            Console.WriteLine("Writing " + filename);
            using (var stringwriter = new StreamWriter(filename))
            {
                var writer = new HtmlWriter(stringwriter);
                writer.BuildToC(reflection, documentation);
            }

            // contents
            foreach(var type in reflection.Types)
            {
                string tocfilename = HttpUtility.UrlEncode(type.FullName) + ".html";
                Console.WriteLine("Writing " + tocfilename);
                using (var stringwriter = new StreamWriter(tocfilename))
                {
                    var member = documentation.GetMemberById(type.FullName);
                    var writer = new HtmlWriter(stringwriter);
                    writer.BuildContents(type, member);
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
