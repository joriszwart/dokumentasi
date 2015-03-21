﻿using System;
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
            foreach(var type in reflection.Types)
            {
                using (var stringwriter = new StreamWriter(HttpUtility.UrlEncode(type.Name) + ".html"))
                {
                    var writer = new HtmlWriter(type, documentation, stringwriter);
                    writer.Build();
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
