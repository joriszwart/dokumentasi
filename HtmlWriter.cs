using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace dokumentasi
{
    class HtmlWriter
    {
        public void BuildContents(Type type, DocumentationMember member)
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.topic)))
            {
                transform.Load(reader);
                transform.Transform("SomeNamespace.SomeClass.xml", "topic-xml.html");
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

    }
}
