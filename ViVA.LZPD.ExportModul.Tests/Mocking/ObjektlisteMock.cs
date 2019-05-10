using System;
using System.Collections;
using System.Collections.Generic;
using Poliks.Application.External.API.Common.Tools;
using Poliks.Application.External.API.Vorgangsbearbeitung.Model;

namespace ViVA.LZPD.ExportModul.Tests.Mocking
{
    internal class ObjektlisteMock<T> : IObjektliste<T>
    {
        private readonly List<T> _objektliste;

        internal ObjektlisteMock()
        {
            _objektliste = new List<T>();
        }

        public IIndexListe<T> this[string name] => throw new System.NotImplementedException();

        public T this[int index] { get { return _objektliste[index]; } }

        public int Anzahl { get { return _objektliste.Count; } }

        public IIndexListe<T> Element(string name)
        {
            throw new System.NotImplementedException();
        }

        public T Element(int index)
        {
            return this[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _objektliste.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _objektliste.GetEnumerator();
        }

        internal void Add(T objekt)
        {
            _objektliste.Add(objekt);
        }

        internal void AddRange(IEnumerable<T> objekte)
        {
            _objektliste.AddRange(objekte);
        }

        internal bool Contains(T personalieVorgangsobjekt)
        {
            return _objektliste.Contains(personalieVorgangsobjekt);
        }
    }
}