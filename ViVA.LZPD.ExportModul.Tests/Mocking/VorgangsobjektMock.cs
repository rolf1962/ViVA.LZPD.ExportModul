using Poliks.Application.External.API.Common.Tools;
using Poliks.Application.External.API.Vorgangsbearbeitung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViVA.LZPD.ExportModul.Tests.Mocking
{
    internal class VorgangsobjektMock : IVorgangsobjekt
    {
        private readonly ObjektlisteMock<IVorgangsobjekt> _vorgangsobjekte = new ObjektlisteMock<IVorgangsobjekt>();
        private readonly ObjektlisteMock<IBeziehung> _beziehungen = new ObjektlisteMock<IBeziehung>();
        private readonly AttributeIndexerMock _attribute = new AttributeIndexerMock();

        internal VorgangsobjektMock(string typ, int objektID)
        {
            Typ = typ;
            ObjektID = objektID;
        }

        public IObjektliste<IVorgangsobjekt> Vorgangsobjekte { get { return _vorgangsobjekte; } }
        public IObjektliste<IBeziehung> Beziehungen { get { return _beziehungen; } }
        public IAttributeIndexer Attribute { get { return _attribute; } }
        public string Typ { get; }
        public long ObjektID { get; }
    }
}
