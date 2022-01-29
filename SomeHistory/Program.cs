using System;
using System.Collections;
using System.Collections.Generic;

namespace SomeHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region What happened once
            // A long time ago in an old .Net framework version...
            // there were no Generics wrappers for simple things like lists, 
            // you had to creat each of a kind:
            var carlist = new CarList();
            carlist.Add(new Car());

            var intlist = new IntList();
            intlist.Add(1);
            intlist.Add(2);
            #endregion


            #region What happened twice
            // so Billy and company thought about a way to get by... the infamous ArrayList
            // Reason why you should never use an ArrayList:
            // - Performance: every get/set will implicate a boxing/unboxing operation
            // - Unsafe: may produce runtime errors, like our old 'dynamic' friend
            ArrayList arrayList = new()
            {
                "a string",
                12.2,
                new Car { Brand = "Audi", Color = "Grey" }
            };

            // the developer did not lose focus on the types
            var secondsValue = (double)arrayList[1];

            // the developer lost focus on the types... runtime exception
            var thirdValue = (double)arrayList[2];
            #endregion


            #region And we're good to go 🎉🎉
            // so how can we reuse code, be performant and type safe?
            // Generic Collections
            var carsList = new List<Car>();
            carsList.Add(new Car());

            var intsList = new List<int>();
            intsList.Add(1);
            intsList.Add(2);

            // so this things are awesome, the collection is not typed but is just a template
            // once the template is used with a real-strong type (primitive, struct, object..) we get a typed collection
            // this way we enhance a lot of advantages:
            // - reusable code: dont need to create a list for each kind
            // - type safety: the compiler will not allow me to Add a strange-type value, not defined at creation
            // - better performance: no boxing/unboxing because the list is typed, no casts, no waste of resources

            // same for dictionaries:
            var intStringDict = new Dictionary<int, string>();
            intStringDict.Add(1, "value");
            #endregion
        }
    }
}
