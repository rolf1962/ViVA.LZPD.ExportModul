using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Poliks.Application.External.API.Vorgangsbearbeitung.Model;

namespace ViVA.LZPD.ExportModul.Tests.Mocking
{
    internal class AttributeIndexerMock : IAttributeIndexer
    {
        private readonly List<Attribut> _attribute;

        internal AttributeIndexerMock()
        {
            _attribute = new List<Attribut>();
        }

        public Attribut this[int index] { get { return _attribute[index]; } }

        public Attribut this[string name]
        {
            get { return _attribute.FirstOrDefault(a => a.Name.Equals(name)); }
            set
            {
                Attribut attribut = _attribute.FirstOrDefault(a => a.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                if (null == attribut)
                {
                    _attribute.Add(value);
                }
                else
                {
                    _attribute.Remove(attribut);
                }
            }
        }

        public int Anzahl { get { return _attribute.Count; } }

        public Attribut Element(string name)
        {
            return _attribute.FirstOrDefault(a => a.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        public Attribut Element(int index)
        {
            return _attribute[index];
        }

        public IEnumerator<Attribut> GetEnumerator()
        {
            return _attribute.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _attribute.GetEnumerator();
        }

        internal void Add(Attribut attribut)
        {
            _attribute.Add(attribut);
        }

        internal void AddRange(IEnumerable<Attribut> attribute)
        {
            _attribute.AddRange(attribute);
        }
    }
}