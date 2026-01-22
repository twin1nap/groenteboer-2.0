using Org.BouncyCastle.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDb.models.dashboard
{
    public class AverageAmountSpend
    {
        public string omschrijving {  get; set; }
        public decimal amount { get; set; } //math.round(value, 2)
    }
}
