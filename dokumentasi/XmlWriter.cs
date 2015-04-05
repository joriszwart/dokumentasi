using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace dokumentasi
{
    class XmlWriter
    {
        TextWriter writer;

        public XmlWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        public void BuildToC(TypeInfo[] types)
        {
            var serializer = new XmlSerializer(types.GetType());
            serializer.Serialize(writer, types);
        }

        public void BuildContents(TypeInfo type, XElement member)
        {
            var serializer = new XmlSerializer(type.GetType());
            serializer.Serialize(writer, type);
        }
    }
}
