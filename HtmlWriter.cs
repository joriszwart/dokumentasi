using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml;
using System.Xml.Xsl;

namespace dokumentasi
{
    class HtmlWriter
    {
        HtmlTextWriter writer;

        public HtmlWriter(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine(" <head>");
            writer.WriteLine(@"  <meta charset=""utf-8"">");
            writer.WriteLine("  <title></title>");
            writer.WriteLine("  <style>");
            writer.WriteLine(Properties.Resources.style);
            writer.WriteLine("  </style>");
            writer.WriteLine(" </head>");
            writer.WriteLine(" <body>");
            this.writer = new HtmlTextWriter(writer, "  ");
        }

        public void BuildContents(Type type, DocumentationMember member)
        {
            // header
            writer.WriteFullBeginTag("h1");
            writer.WriteEncodedText(type.GetSignature());
            writer.WriteEndTag("h1");

            // summary
            if(member != null && member.Summary != null)
            {
                writer.WriteFullBeginTag("p");
                writer.WriteEncodedText(member.Summary);
                writer.WriteEndTag("p");
            }
            
            // inheritance
            writer.WriteFullBeginTag("h2");
            writer.Write("Inheritance");
            writer.WriteEndTag("h2");

            var typenames = new Stack<string>();
            var thistype = type;
            do
            {
                typenames.Push(thistype.FullName);
                thistype = thistype.BaseType;
            } while (thistype != null);

            foreach(var typename in typenames)
            {
                writer.WriteFullBeginTag("ul");
                writer.WriteFullBeginTag("li");
                writer.AddAttribute("href", typename + ".html", true);
                writer.RenderBeginTag("a");
                writer.Write(typename);
                writer.RenderEndTag();
            }

            var descendants = from t in type.Assembly.GetTypes() 
                              where t.BaseType == type
                              select t;
            writer.WriteFullBeginTag("ul");
            foreach (var descendant in descendants)
            {
                writer.WriteFullBeginTag("li");
                writer.AddAttribute("href", descendant.FullName + ".html", true);
                writer.RenderBeginTag("a");
                writer.Write(descendant.FullName);
                writer.RenderEndTag();
                writer.WriteEndTag("li");
            }
            writer.WriteEndTag("ul");

            foreach (var typename in typenames)
            {
                writer.WriteEndTag("li");
                writer.WriteEndTag("ul");
            }

            // namespace and assembly
            writer.WriteFullBeginTag("dl");
            writer.WriteFullBeginTag("dt");
            writer.Write("Namespace");
            writer.WriteEndTag("dt");
            writer.WriteFullBeginTag("dd");
            writer.Write(type.Namespace);
            writer.WriteEndTag("dd");
            writer.WriteFullBeginTag("dt");
            writer.Write("Assembly");
            writer.WriteEndTag("dt");
            writer.WriteFullBeginTag("dd");
            writer.Write(type.Assembly.GetName().Name + " (in " + Path.GetFileName(type.Assembly.Location) + ")");
            writer.WriteEndTag("dd");
            writer.WriteEndTag("dl");

            // constructors
            var constructors = type.GetConstructors();
            Array.Sort(constructors, new ConstructorInfoComparer());

            writer.WriteFullBeginTag("h2");
            writer.Write("Constructors");
            writer.WriteEndTag("h2");
            writer.WriteFullBeginTag("table");
            writer.WriteFullBeginTag("tr");
            writer.WriteFullBeginTag("th");
            writer.Write("Modifiers");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Name");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Description");
            writer.WriteEndTag("th");
            writer.WriteEndTag("tr");
            foreach (var constructor in constructors)
            {
                writer.WriteFullBeginTag("tr");
                writer.WriteFullBeginTag("td");
                writer.Write(constructor.GetModifiers());
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText(constructor.GetSignature());
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("constructor description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");

            // methods
            var methods = type.GetMethods();
            Array.Sort(methods, new MethodInfoComparer());

            writer.WriteFullBeginTag("h2");
            writer.Write("Methods");
            writer.WriteEndTag("h2");
            writer.WriteFullBeginTag("table");
            writer.WriteFullBeginTag("tr");
            writer.WriteFullBeginTag("th");
            writer.Write("Modifiers");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Name");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Description");
            writer.WriteEndTag("th");
            writer.WriteEndTag("tr");
            foreach (var method in methods)
            {
                writer.WriteFullBeginTag("tr");
                writer.WriteFullBeginTag("td");
                writer.Write(method.GetModifiers());
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText(method.GetSignature());
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("method description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");

            // events
            var events = type.GetEvents();
            Array.Sort(events, new EventInfoComparer());

            writer.WriteFullBeginTag("h2");
            writer.Write("Events");
            writer.WriteEndTag("h2");
            writer.WriteFullBeginTag("table");
            writer.WriteFullBeginTag("tr");
            writer.WriteFullBeginTag("th");
            writer.Write("Name");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Description");
            writer.WriteEndTag("th");
            writer.WriteEndTag("tr");
            foreach (var @event in events)
            {
                writer.WriteFullBeginTag("tr");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText(@event.Name);
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("event description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");

            // fields
            var fields = type.GetFields();
            Array.Sort(fields, new FieldInfoComparer());

            writer.WriteFullBeginTag("h2");
            writer.Write("Fields");
            writer.WriteEndTag("h2");
            writer.WriteFullBeginTag("table");
            writer.WriteFullBeginTag("tr");
            writer.WriteFullBeginTag("th");
            writer.Write("Modifiers");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Name");
            writer.WriteEndTag("th");
            writer.WriteFullBeginTag("th");
            writer.Write("Description");
            writer.WriteEndTag("th");
            writer.WriteEndTag("tr");
            foreach (var field in fields)
            {
                writer.WriteFullBeginTag("tr");
                writer.WriteFullBeginTag("td");
                writer.Write(field.IsPublic);
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText(field.Name);
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("method description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");

            // remarks
            if (member != null && member.Remarks != null)
            {
                writer.WriteFullBeginTag("p");
                writer.WriteEncodedText(member.Remarks);
                writer.WriteEndTag("p");
            }
        }

        public void BuildToC(Reflection reflection, Documentation documentation)
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.toc)))
            {
                transform.Load(reader);
                transform.Transform("toc.xml", "toc-xml.html");
            }
        }

        public void Dispose()
        {
            writer.WriteLine(" </body>");
            writer.WriteLine("</html>");
            writer.Dispose();
        }

    }
}
