using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTTest.Models
{
    public class Symbol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string Isin { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime DateAdded { get; set; }
        public float Price { get; set; }

        public DateTime PriceDate { get; set; }
        public Type Typ { get; set; }
        public Exchange Exc { get; set; }



    }
}
