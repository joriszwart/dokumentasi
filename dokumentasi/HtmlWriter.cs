using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace dokumentasi
{
    class HtmlWriter
    {
        public void BuildContents(Type type, XElement member)
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.topic)))
            {
                transform.Load(reader);
                string xmlfilename = type.FullName + ".xml";
                string htmlfilename = type.FullName + ".html";
                transform.Transform(xmlfilename, htmlfilename);
            }
        }

        public void BuildToC(Reflection reflection, Documentation documentation)
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.toc)))
            {
                transform.Load(reader);
                transform.Transform("toc.xml", "toc.html");
            }
        }

    }
}
