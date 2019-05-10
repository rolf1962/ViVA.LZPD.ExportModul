using Poliks.Application.External.API.Vorgangsbearbeitung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using ViVA.LZPD.ExportModul.DataAccess;
using ViVA.LZPD.Thesaurus;

namespace ViVA.LZPD.ExportModul.Tests.Mocking
{
    internal static class VorgangsobjektFactory
    {
        private static Assembly thesaurusAssembly = Assembly.GetAssembly(typeof(Datenobjekte));

        /// <summary>
        /// Sucht im <see cref="Thesaurus"/> nach dem <see cref="Datenobjekte.Datenobjekt"/> mit dem Namen 
        /// aus <paramref name="datenobjektname"/> und legt ein leeres <see cref="IVorgangsobjekt"/> 
        /// mit allen Attributen an.
        /// </summary>
        /// <param name="datenobjektname">Der Name eines <see cref="Datenobjekte.Datenobjekt"/> aus dem <see cref="Thesaurus"/></param>
        /// <returns>Ein <see cref="IVorgangsobjekt"/></returns>
        internal static IVorgangsobjekt Create(string datenobjektname)
        {
            var datenobjektType = thesaurusAssembly.ExportedTypes.FirstOrDefault(t => t.Name.Equals(datenobjektname));

            if (null == datenobjektType)
            {
                throw new TypeAccessException($"Der Typ {datenobjektname} wurde nicht gefunden.");
            }

            VorgangsobjektMock vorgangsobjekt = new VorgangsobjektMock(datenobjektname, ObjektIDFactory.GetNextValue());
            var attribute = datenobjektType.GetNestedType("Attribute").GetNestedTypes();
            var attributelist = attribute.Select(t =>
             {
                 var attribut = Mock.Create<Attribut>();

                 PrivateAccessor attributeAccessor = new PrivateAccessor(attribut);
                 attributeAccessor.SetMember("_name", t.Name);

                 return attribut;
             });

            ((AttributeIndexerMock)vorgangsobjekt.Attribute).AddRange(attributelist);

            return vorgangsobjekt;
        }
    }
}
