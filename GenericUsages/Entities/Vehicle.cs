using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUsages.Entities
{
    public class Vehicle<T>
    {
        public Vehicle(T id) {
            Id = id;
        }

        public T Id { get; set; }
        public string Name { get; set; }
    }
}
