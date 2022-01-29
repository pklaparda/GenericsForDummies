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
            var pepe = new Pepe();
            var pepo = new Pepo();
        }

        public Car this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public abstract class Pepo
    {

    }
    public class Pepe<T>
    {

    }
}
