using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDb.models.dashboard
{
    public class AnnualTurnoverOverview
    {
        public int Totaal_aantal_verkopen {  get; set; }
        public decimal Totale_jaaromzet { get; set; }
        public decimal Gemiddelde_omzet_per_verkoop { get; set; }
    }
}
