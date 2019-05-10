using Poliks.Application.External.API.Vorgangsbearbeitung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViVA.LZPD.ExportModul.DataAccess
{
    public class Datenobjekt<T> where T : IVorgangsobjekt
    {
        public Datenobjekt(T vorgangsobjekt)
        {
            Vorgangsobjekt = vorgangsobjekt;
        }

        public T Vorgangsobjekt { get; }
    }
}
