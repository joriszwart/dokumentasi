using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace dokumentasi
{
    class Documentation
    {
        XDocument document;

        public Documentation(string filename)
        {
            this.document = XDocument.Load(filename);
        }

        public string Assembly
        {
            get
            {
                var assembly = document.Root.Element("assembly");
                return assembly.Element("name").Value;
            }
        }

        public IEnumerable<DocumentationMember> Members
        {
            get
            {
                var members = document.Descendants("member");
                foreach(var member in members)
                {
                    yield return new DocumentationMember(member);
                }
            }
        }
    }

    enum MemberType { Error, Event, Field, Method, Namespace, Property, Type };

    class DocumentationMember
    {
        private XElement member;

        public DocumentationMember(XElement member)
        {
            this.member = member;
            this.Name = member.Attribute("name").Value;

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
 
        public string Summary
        {
            get
            {
                var summary = member.Element("summary");
                return summary.Value; 
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
                return summary.Value; 
            }
        }

    }
}
