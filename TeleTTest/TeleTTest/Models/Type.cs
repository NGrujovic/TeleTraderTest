using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTTest.Models
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }


        public override string ToString()
        {
            return TypeName.ToString();
        }
    }
}
