using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUsages.Entities
{
    public class Currency : Item
    {
        //public Currency(int id, string name, string shortName) : base(id, name)
        //{
        //    ShortName = shortName;
        //}
        ////public Currency() : base(1, "")
        ////{

        ////}

        public string ShortName { get; set; }
    }
}
