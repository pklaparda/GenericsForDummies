using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SomeHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What happened once
            // A long time ago in an old .Net framework version...
            // there were no Generics collections (lists), 
            // you had to creat each of a kind:
            var carlist = new CarList();
            carlist.Add(new Car());

            var intlist = new IntList();
            intlist.Add(1);
            intlist.Add(2);
            #endregion


            #region What happened twice
            // so Billy and company thought about a way improve things... the infamous ArrayList & HashTable
            // Reason why you should never use an ArrayList:
            // - Performance: every get/set will implicate a boxing/unboxing operation
            // - Unsafe: may produce runtime errors, like our old 'dynamic' friend
            ArrayList arrayList = new()
            {
                13.4,
                12.2,
                new Car { Brand = "Audi", Color = "Grey" }
            };

            // the developer did not lose focus on the types
            var secondsValue = (double)arrayList[1];

            try
            {
                // the developer lost focus on the types... runtime exception... this try catch may not be there..
                var thirdValue = (double)arrayList[2];
            }
            catch (InvalidCastException icEx)
            {
                Console.WriteLine(icEx.Message);
            }

            var carHashtable = new Hashtable();
            carHashtable.Add("carOne", 1.1);
            carHashtable.Add("carTwo", new Car { Brand = "Ford"});
            carHashtable.Add("carthree", 2.2);

            try
            {
                // the developer lost focus on the types... runtime exception... this try catch may not be there..
                var letsBreakIt = (double)carHashtable["carTwo"];
            }
            catch (InvalidCastException icEx)
            {
                Console.WriteLine(icEx.Message);
            }

            // boxing and unboxing made these hash/array not be so performant..
            Stopwatch stopwatch = new Stopwatch();
            arrayList.Clear();
            stopwatch.Start();
            for (int i = 0; i < 3000; i++)
                arrayList.Add(new Car { Brand = $"Audi{i}" });
            foreach(Car car in arrayList)
            {
                Console.WriteLine($"this {car.Brand} is great");
            }
            stopwatch.Stop();
            var arrayListTime = (double)stopwatch.ElapsedMilliseconds / 1000;
            
            stopwatch.Reset();


            #endregion


            #region And we're good to go 🎉🎉
            // so how can we reuse code, be performant and type safe?
            // Generic Collections
            var carsList = new List<Car>();
            carsList.Add(new Car());

            var intsList = new List<int>();
            intsList.Add(1);
            intsList.Add(2);
            //intsList.Add("3"); // not allowed at compilation time

            // so this things are awesome, the collection is not typed but is just a template
            // once the template is used with a real-strong type (primitive, struct, object..) we get a typed collection
            // this way we enhance a lot of advantages:
            // - reusable code: dont need to create a list for each kind
            // - type safety: the compiler will not allow me to Add a strange-type value, not defined at creation
            // - better performance: no boxing/unboxing because the list is typed, no casts, no waste of resources

            // same for dictionaries:
            var intStringDict = new Dictionary<int, string>();
            intStringDict.Add(1, "value1");
            intStringDict.Add(2, "value2");
            // intStringDict.Add("3", "value3"); //not allowed at compilation time

            // performance with generic collections is better because is ditching the boxing/unboxing waste
            var gCarList = new List<Car>();
            stopwatch.Start();
            for (int i = 0; i < 3000; i++)
                gCarList.Add(new Car { Brand = $"Audi{i}" });
            foreach (Car car in arrayList)
            {
                Console.WriteLine($"this {car.Brand} is great");
            }
            stopwatch.Stop();

            Console.WriteLine($"Using ArrayList took us ${arrayListTime} seconds.");
            Console.WriteLine($"Using Generic List took us ${(double)stopwatch.ElapsedMilliseconds / 1000} seconds.");

            stopwatch.Reset();
            #endregion
        }
    }
}
