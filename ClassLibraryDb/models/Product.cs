using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDb.models
{
    public class Product
    {
        public int id { get ; set; }
        public string ProductNaam { get; set; }
        public bool PriceType { get; set; }
        public decimal ProductPrijs { get; set; }
        public Image ProductImage { get; set; }
        public int categoryId { get; set; }
    }
}
