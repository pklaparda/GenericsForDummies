using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeHistory
{
    public class CarList
    {
        private Car[] data;
        private int size = 0;
        private int capacity;
        public void Add(Car car)
        {
            // not our business
        }

        public Car this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

}
