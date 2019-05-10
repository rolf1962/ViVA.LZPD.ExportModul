using Poliks.Application.External.API.Vorgangsbearbeitung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViVA.LZPD.ExportModul.DataAccess
{
    public class DatenobjektAnwendungsfall : Datenobjekt<IVorgangsobjekt>
    {
        public DatenobjektAnwendungsfall(IVorgangsobjekt vorgangsobjekt) : base(vorgangsobjekt)
        {
        }
    }
}
