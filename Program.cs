﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

            tocfilename = "toc.html";
            Console.WriteLine("Writing " + tocfilename);
            using (var stringwriter = new StreamWriter(tocfilename))
            {
                var writer = new HtmlWriter();
                writer.BuildToC(reflection, documentation);
            }

            // contents
            foreach(var type in reflection.Types)
            {
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
                    AssemblyFileName = type.Assembly.Location,
                    Constructors = (from constructor in constructors select new Constructor { Signature = constructor.GetSignature(), FullName = constructor.Name }).ToArray(),
                    Methods = (from method in methods select new Method { Signature = method.GetSignature(), Name = method.Name }).ToArray(),
                    Events = (from @event in events select new Event() ).ToArray(),
                    Fields = (from field in fields select new Field() ).ToArray(),
                    Remarks = member != null ? member.Remarks : "no remarks"
                };

                string filename = WebUtility.UrlEncode(type.FullName) + ".html";
                Console.WriteLine("Writing " + filename);
                using (var stringwriter = new StreamWriter(filename))
                {
                    var writer = new HtmlWriter();
                    writer.BuildContents(type, member);
                }

                filename = WebUtility.UrlEncode(type.FullName) + ".xml";
                Console.WriteLine("Writing " + filename);
                using (var streamwriter = new StreamWriter(filename))
                {
                    var xmlwriter = new XmlWriter(streamwriter);
                    xmlwriter.BuildContents(typeinfo, member);
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
