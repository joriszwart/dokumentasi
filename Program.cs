using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

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
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: dokumentasi <assembly name>");
                return;
            }

            var documentation = new Documentation(args[0] + ".xml");
            Console.WriteLine("assembly: " + documentation.Assembly);
            foreach(var member in documentation.Members)
            {
                Console.WriteLine("  member: " + member.Name);
            }

            Console.WriteLine("---------------------------------");

            var assembly = Assembly.Load(args[0]);
            var reflection = new Reflection(assembly);

            // style
            File.WriteAllText("dokumentasi.css", Properties.Resources.style);

            // table of contents
            string tocfilename = "toc.xml";
            Console.WriteLine("Writing " + tocfilename);
            using (var streamwriter = new StreamWriter(tocfilename))
            {
                var types = (from type in reflection.Types
                             orderby type.FullName
                            select new TypeInfo { FullName = type.FullName, Id = type.FullName }).ToArray<TypeInfo>();

                var xmlwriter = new XmlWriter(streamwriter);
                xmlwriter.BuildToC(types);
                streamwriter.Close();
            }

            Console.WriteLine("Writing toc.xml");
            var tocwriter = new HtmlWriter();
            tocwriter.BuildToC(reflection, documentation);

            // contents
            foreach(var type in reflection.Types)
            {
                if (type.FullName.StartsWith("<PrivateImplementationDetails>"))
                {
                    continue;
                }

                var member = documentation.GetMemberById(type.FullName);

                var inheritance = type.GetClassHierarchy();

                var constructors = type.GetConstructors();
                Array.Sort(constructors, new ConstructorInfoComparer());
                var methods = type.GetMethods();
                Array.Sort(methods, new MethodInfoComparer());
                var events = type.GetEvents();
                Array.Sort(events, new EventInfoComparer());
                var fields = type.GetFields();
                Array.Sort(fields, new FieldInfoComparer());

                var typeinfo = new TypeInfo
                {
                    FullName = type.FullName,
                    Id = type.FullName,
                    Summary = member != null ? member.Summary : "no summary",
                    Inheritance = inheritance,
                    Namespace = type.Namespace,
                    AssemblyName = type.Assembly.GetName().Name,
                    AssemblyFileName = Path.GetFileName(type.Assembly.Location),
                    Constructors = (from constructor in constructors select new Constructor { Signature = constructor.GetSignature(), FullName = constructor.Name }).ToArray(),
                    Methods = (from method in methods select new Method { Signature = method.GetSignature(), Name = method.Name }).ToArray(),
                    Events = (from @event in events select new Event() ).ToArray(),
                    Fields = (from field in fields select new Field() ).ToArray(),
                    Remarks = member != null ? member.Remarks : "no remarks"
                };

                string filename = WebUtility.UrlEncode(type.FullName) + ".xml";
                Console.WriteLine("Writing " + filename);
                using (var streamwriter = new StreamWriter(filename))
                {
                    var xmlwriter = new XmlWriter(streamwriter);
                    xmlwriter.BuildContents(typeinfo, member);
                }

                filename = WebUtility.UrlEncode(type.FullName) + ".html";
                Console.WriteLine("Writing " + filename);
                var topicwriter = new HtmlWriter();
                topicwriter.BuildContents(type, member);
            }

            if(Debugger.IsAttached)
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
