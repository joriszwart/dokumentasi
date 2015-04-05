using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace dokumentasi
{
    class HtmlWriter
    {
        public void BuildToC()
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.toc)))
            {
                transform.Load(reader);
                transform.Transform("toc.xml", "index.html");
            }
        }

        public void BuildContent(string xmlfilename, string htmlfilename)
        {
            var transform = new XslCompiledTransform();
            using (var reader = XmlReader.Create(new StringReader(Properties.Resources.topic)))
            {
                transform.Load(reader);
                transform.Transform(xmlfilename, htmlfilename);
            }
        }
    }
}
