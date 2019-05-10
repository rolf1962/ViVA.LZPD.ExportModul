using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poliks.Application.External.API.Vorgangsbearbeitung.Model;
using Telerik.JustMock;
using ViVA.LZPD.ExportModul.Tests.Mocking;
using ViVA.LZPD.Thesaurus;

namespace ViVA.LZPD.ExportModul.Tests
{
    [TestClass]
    public class MockingTests
    {
        [TestMethod]
        public void ErzeugeVorgangsobjektPersonMitPersonalie()
        {
            IVorgangsobjekt personVorgangsobjekt = VorgangsobjektFactory.Create(Datenobjekte.Person.Name);
            Assert.IsNotNull(personVorgangsobjekt, $"{nameof(personVorgangsobjekt)} darf nicht null sein");

            personVorgangsobjekt.Attribute[Datenobjekte.Person.Attribute.angelegtAm.Name].Wert = DateTime.Now;
            personVorgangsobjekt.Attribute[Datenobjekte.Person.Attribute.titel.Name].Wert = "Jansen, Rolf";

            IVorgangsobjekt personalieVorgangsobjekt = VorgangsobjektFactory.Create(Datenobjekte.Personalie.Name);
            Assert.IsNotNull(personalieVorgangsobjekt, $"{nameof(personalieVorgangsobjekt)} darf nicht null sein");

            personalieVorgangsobjekt.Attribute[Datenobjekte.Personalie.Attribute.angelegtAm.Name].Wert = DateTime.Now;
            personalieVorgangsobjekt.Attribute[Datenobjekte.Personalie.Attribute.vorname.Name].Wert = "Rolf";
            personalieVorgangsobjekt.Attribute[Datenobjekte.Personalie.Attribute.familienEhename.Name].Wert = "Jansen";
            personalieVorgangsobjekt.Attribute[Datenobjekte.Personalie.Attribute.geburtsdatumUIVon.Name].Wert = new DateTime(1962, 2, 24);


            ((ObjektlisteMock<IVorgangsobjekt>)personVorgangsobjekt.Vorgangsobjekte).Add(personalieVorgangsobjekt);
            Assert.IsTrue(((ObjektlisteMock<IVorgangsobjekt>)personVorgangsobjekt.Vorgangsobjekte).Contains(personalieVorgangsobjekt));
        }
    }
}
