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
            var oldCarlist = new CarList();
            oldCarlist.Add(new Car());

            var oldIntlist = new IntList();
            oldIntlist.Add(1);
            oldIntlist.Add(2);
            #endregion

            //----------------------------------------------------------------------------------------------

            #region What happened twice
            // so Billy and company thought about a way improve things... the infamous ArrayList & HashTable
            // Reason why you should NEVER use an ArrayList:
            // - Performance: every get/set will implicate a boxing/unboxing operation
            // - Unsafe: may produce runtime errors, like our 'dynamic' friend
            ArrayList numbersList = new()
            {
                13.4,
                12.2,
                new Car { Brand = "Audi", Color = "Grey" }
            };

            // the developer did not lose focus on the types
            var someDoubleValue = (double)numbersList[1];

            try
            {
                // the developer lost focus on the types... runtime exception... this try catch may not be there..
                var someNotDoubleValue = (double)numbersList[2];
            }
            catch (InvalidCastException icEx)
            {
                Console.WriteLine(icEx.Message);
            }

            // example for Hashtable
            var numbersHashtable = new Hashtable
            {
                { "one", 1.1 },
                { "two", new Car { Brand = "Ford" } },
                { "three", 2.2 }
            };

            try
            {
                // the developer lost focus on the types... runtime exception... this try catch may not be there..
                var notANumber = (double)numbersHashtable["two"];
            }
            catch (InvalidCastException icEx)
            {
                Console.WriteLine(icEx.Message);
            }


            // boxing and unboxing made these hash/array not so performant..
            Stopwatch stopwatch = new Stopwatch();
            numbersList.Clear();
            stopwatch.Start();
            // so bizare.. I can use the number list for cars if I want to...
            for (int i = 0; i < 5000; i++)
                numbersList.Add(new Car { Brand = $"Audi{i}" });
            foreach(var car in numbersList)
            {
                Console.WriteLine($"this {((Car)car).Brand} is great");
            }
            stopwatch.Stop();
            var arrayListTime = (double)stopwatch.ElapsedMilliseconds / 1000;
            stopwatch.Reset();


            #endregion

            //----------------------------------------------------------------------------------------------

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
            var dict = new Dictionary<int, string>();
            dict.Add(1, "value1");
            dict.Add(2, "value2");
            // intStringDict.Add("3", "value3"); //not allowed at compilation time

            // performance with generic collections is better because is ditching the boxing/unboxing waste
            carsList = new List<Car>();
            stopwatch.Start();
            for (int i = 0; i < 5000; i++)
                carsList.Add(new Car { Brand = $"Audi{i}" });
            foreach (var car in carsList)
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
