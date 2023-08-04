using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTTest.Models
{
    public class Exchange
    {
        public int ExchangeId { get; set; }
        public string ExchangeName { get; set; }

        public override string ToString()
        {
            return ExchangeName.ToString();
        }
    }
}
