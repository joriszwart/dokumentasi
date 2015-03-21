using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace dokumentasi
{
    class HtmlWriter
    {
        Type type;
        Documentation documentation;
        HtmlTextWriter writer;

        public HtmlWriter(Type type, Documentation documentation, TextWriter writer)
        {
            this.type = type;
            this.documentation = documentation;

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine(" <head>");
            writer.WriteLine(@"  <meta charset=""utf-8"">");
            writer.WriteLine("  <title></title>");
            writer.WriteLine(" </head>");
            writer.WriteLine(" <body>");
            writer.WriteLine("  <style>");
            writer.WriteLine("  body {");
            writer.WriteLine("    background: white;");
            writer.WriteLine("    color: black;");
            writer.WriteLine("    font: 14px/1.5 sans-serif");
            writer.WriteLine("  }");
            writer.WriteLine("  table {");
            writer.WriteLine("    border-collapse: collapse;");
            writer.WriteLine("    table-layout: fixed;");
            writer.WriteLine("    width: 100%");
            writer.WriteLine("  }");
            writer.WriteLine("  table, th, td {");
            writer.WriteLine("    border: 1px solid gray;");
            writer.WriteLine("    padding: .5em;");
            writer.WriteLine("    text-align: left;");
            writer.WriteLine("    vertical-align: top");
            writer.WriteLine("  }");
            writer.WriteLine("  th {");
            writer.WriteLine("    background: lightgrey;");
            writer.WriteLine("  }  ");
            writer.WriteLine("  </style>");
            this.writer = new HtmlTextWriter(writer, "  ");
        }

        public void Build()
        {
            writer.WriteFullBeginTag("h1");
            writer.WriteEncodedText(type.GetSignature());
            writer.WriteEndTag("h1");

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
                writer.Write(method.GetSignature());
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("method description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");

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
                writer.Write(field.Name);
                writer.WriteEndTag("td");
                writer.WriteFullBeginTag("td");
                writer.WriteEncodedText("method description");
                writer.WriteEndTag("td");
                writer.WriteEndTag("tr");
            }
            writer.WriteEndTag("table");
        }

        public void Dispose()
        {
            writer.WriteLine(" </body>");
            writer.WriteLine("</html>");
            writer.Dispose();
        }

    }
}
