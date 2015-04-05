using System.Collections.Generic;
using System.Xml.Linq;

namespace dokumentasi
{
    class Documentation
    {
        XDocument document;
        Dictionary<string, XElement> members;

        public Documentation(string filename)
        {
            this.document = XDocument.Load(filename);
            this.members = new Dictionary<string, XElement>();
            foreach (var member in document.Descendants("member"))
            {
                string id = member.Attribute("name").Value.Substring(2);
                members.Add(id, member);
            }
        }

        public string Assembly
        {
            get
            {
                var assembly = document.Root.Element("assembly");
                return assembly.Element("name").Value;
            }
        }

        public XElement GetMemberById(string id)
        {
            XElement member;
            members.TryGetValue(id, out member);
            return member;
        }
    }

    public enum MemberType { Error, Event, Field, Method, Namespace, Property, Type };

    public class DocumentationMember
    {
        private XElement member;

        public DocumentationMember(XElement member)
        {
            this.member = member;
            this.Name = member.Attribute("name").Value;
            this.Id = this.Name.Substring(2);

            switch (Name[0])
            {
                case 'E':
                    this.MemberType = MemberType.Event;
                    break;

                case 'F':
                    this.MemberType = MemberType.Field;
                    break;

                case 'M':
                    this.MemberType = MemberType.Method;
                    break;

                case 'N':
                    this.MemberType = MemberType.Namespace;
                    break;

                case 'P':
                    this.MemberType = MemberType.Property;
                    break;

                case 'T':
                    this.MemberType = MemberType.Type;
                    break;

                case '!':
                    this.MemberType = MemberType.Error;
                    break;

                default:
                    this.MemberType = MemberType.Error;
                    break;
            }

        }

        public MemberType MemberType { get; internal set; }
        public string Name { get; internal set; }
        public string Id { get; internal set; }
 
        public string Summary
        {
            get
            {
                var summary = member.Element("summary");
                return summary != null? summary.Value: null; 
            } 
        }

        public IEnumerable<string> Parameters
        {
            get
            {
                var parameters = member.Elements("param");
                foreach(var parameter in parameters)
                {
                    yield return parameter.Value; 
                }
            }
        }

        public string Returns
        {
            get
            {
                var summary = member.Element("summary");
                return summary.Value;
            }
        }

        public string Remarks
        {
            get
            {
                var summary = member.Element("remarks");
                return summary != null? summary.Value: null; 
            }
        }

    }
}
