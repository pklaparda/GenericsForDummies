using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeHistory
{
    public class Car
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"This is a {Color} {Brand}";
        }
    }
}
