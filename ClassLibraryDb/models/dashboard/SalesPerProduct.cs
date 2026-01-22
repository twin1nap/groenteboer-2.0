using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDb.models.dashboard
{
    public class SalesPerProduct
    {
        public string product {  get; set; }
        public decimal Totaal_Verkocht { get; set; }
        public decimal Totale_omzet { get; set; }
    }
}
