using GenericUsages.Entities;
using GenericUsages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GenericUsages
{
    internal class Program
    {
        // generic method
        public static void LogData<T>(T data)
        {
            Console.WriteLine(data);
        }

        public static T GetDefault<T>(object obj)
        {
            return default(T);
        }

        public static T SafeCast<T>(string strValue) where T : struct
        {
            try
            {
                if (strValue == null || Equals(strValue, DBNull.Value))
                    return default(T);

                return (T)Convert.ChangeType(strValue, typeof(T));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"cannot cast value '{strValue}' to {typeof(T).Name}. Returning default type's value", ex);
                return default(T);
            }
        }


        static void Main(string[] args)
        {
            #region generic methods
            // basics
            LogData<int>(1);
            LogData<Doctor>(new Doctor());
            LogData<string>("string");

            // more basics, default values
            var doubleValue = GetDefault<double>(1.1);
            var boolValue = GetDefault<bool>(true);
            var intValue = GetDefault<int>(2);
            var stringValue = GetDefault<string>("failure");
            var personValue = GetDefault<Person>(null);

            // more basics, safe cast values
            doubleValue = SafeCast<double>("1.1");
            boolValue = SafeCast<bool>("true");
            intValue = SafeCast<int>("2");
            var anotherIntValue = SafeCast<int>("john doe");

            Console.WriteLine();

            //// Generics can be used up to the highest-agnostic-type level
            //// here we have some examples on putting CONSTRAINTS to Generics:

            //// method 'GetToStringLenght()' works for EVERY type
            ///*INT*/
            //Console.WriteLine(1.GetToStringLenght());
            ///*CHAR*/
            //Console.WriteLine('H'.GetToStringLenght());
            ///*BOOLEAN*/
            //Console.WriteLine(false.GetToStringLenght());
            ///*STRING*/
            //Console.WriteLine("Yechiel".GetToStringLenght());
            ///*OBJECT*/
            //Console.WriteLine(new Lawyer().GetToStringLenght());


            //// or you may want to limit the implementation to primitive (STRUCTS) types and don't allow everyone use a method
            //// because maybe is not prepared to hadle any type..
            ///*INT*/
            //Console.WriteLine(1.GetPrimitiveToStringLenght<int>());
            ///*CHAR*/
            //Console.WriteLine('H'.GetPrimitiveToStringLenght());
            ///*BOOLEAN*/
            //Console.WriteLine(false.GetPrimitiveToStringLenght<bool>());
            ///*STRING*/
            //Console.WriteLine("Yechiel".GetPrimitiveToStringLenght());
            ///*OBJECT*/
            //Console.WriteLine(new Lawyer().GetPrimitiveToStringLenght());


            //// same thing if you just want to apply the logic to CLASSES..
            ///*INT*/
            //Console.WriteLine(1.GetObjectToStringLenght<int>());
            ///*CHAR*/
            //Console.WriteLine('H'.GetObjectToStringLenght<char>());
            ///*BOOLEAN*/
            //Console.WriteLine(false.GetObjectToStringLenght<bool>());
            ///*STRING*/
            //Console.WriteLine("Yechiel".GetObjectToStringLenght<string>());
            ///*OBJECT*/
            //Console.WriteLine(new Lawyer().GetObjectToStringLenght<Lawyer>());


            //// same thing if you want to treat specific classes (PERSON)
            ///*CHAR*/
            //Console.WriteLine('H'.GetPersonToStringLenght());
            ///*STRING*/
            //Console.WriteLine("Yechiel".GetPersonToStringLenght());
            ///*PERSON*/
            //Console.WriteLine(new Lawyer().GetPersonToStringLenght());
            ///*PERSON*/
            //Console.WriteLine(new Doctor().GetPersonToStringLenght());
            ///*PERSON*/
            //Console.WriteLine(new Farmer().GetPersonToStringLenght());

            //// same thing if you want to treat specific interfaces (IPROFESSIONAL)
            ///*IPROFESSIONAL*/
            //Console.WriteLine(new Lawyer().GetProfessionalToStringLenght<IProfessional>());
            ///*IPROFESSIONAL*/
            //Console.WriteLine(new Doctor().GetProfessionalToStringLenght<IProfessional>());
            ///*IPROFESSIONAL*/
            //Console.WriteLine(new Farmer().GetProfessionalToStringLenght<IProfessional>());

            #endregion

            #region generic classes

            // basic
            var car = new Vehicle<int>(1526, Vehicles.Car);
            var truck = new Vehicle<Guid>(Guid.NewGuid(), Vehicles.Truck);

            car.Ride();
            truck.Ride();
            // great, how can I list those vehicles and ride them all at once??
            //-----------------------------------------------------------------------------------------------------------------


            // in this example we can get ralated entities to perform the same... well, not same same.
            // let's say I want to put all my workstations to process data
            // even though they are all computers, their serial number is of a different type
            // regardless the serial number, everyithing is the same... how can I list them and process them with polimorphism
            // but have a custom typed-constructor for each??
            new List<IWorkstation>()
            {
                new Pc(1526484),
                new Laptop(Guid.NewGuid())
            }
            .ForEach(workstation =>
            {
                workstation.ProcessData();
                Console.WriteLine($"{workstation.GetType().Name} is done processing. Serial number: '{workstation.GetSerialNumber()}'");
            });



            // another usage: Repository... we might learn about it another day :)
            //-----------------------------------------------------------------------------------------------------------------


            // ref behavior remains the same with Generics, we can modify the value we send
            var someCurrency = new Currency { Id = 1, Name = "NIS", ShortName = "New Israeli Shekel" }; // new Currency(1,"");
            Console.WriteLine($"Hash before modifying: {someCurrency.GetHashCode()}");
            new ReferenceResolver().LogAndReturnBaseValuesOnly(ref someCurrency);
            Console.WriteLine($"I'm not supposed to have a value on ShortName and the hash changed: {someCurrency.GetHashCode()}");

            #endregion

        }
    }
}
