using GenericUsages.Entities;
using GenericUsages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericUsages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region generic methods

            // Generics can be used up to the highest agnostic type level
            Console.WriteLine(1.GetToStringLenght());
            Console.WriteLine('H'.GetToStringLenght());
            Console.WriteLine(false.GetToStringLenght());
            Console.WriteLine("Yechiel".GetToStringLenght());
            Console.WriteLine(new Lawyer().GetToStringLenght());


            // or you may want to limit the implementation to primitive types and don't allow everyone use a method
            // because maybe is not prepared to hadle any type..
            Console.WriteLine(1.GetPrimitiveToStringLenght<int>());
            Console.WriteLine('H'.GetPrimitiveToStringLenght());
            Console.WriteLine(false.GetPrimitiveToStringLenght<bool>());
            Console.WriteLine("Yechiel".GetPrimitiveToStringLenght());
            Console.WriteLine(new Lawyer().GetPrimitiveToStringLenght());


            // same thing if you just want to apply the logic to objects..
            Console.WriteLine(1.GetObjectToStringLenght<int>());
            Console.WriteLine('H'.GetObjectToStringLenght<char>());
            Console.WriteLine(false.GetObjectToStringLenght<bool>());
            Console.WriteLine("Yechiel".GetObjectToStringLenght<string>());
            Console.WriteLine(new Lawyer().GetObjectToStringLenght<Lawyer>());


            // same thing if you want to treat specific classes
            Console.WriteLine('H'.GetPersonToStringLenght());
            Console.WriteLine("Yechiel".GetPersonToStringLenght());
            Console.WriteLine(new Lawyer().GetPersonToStringLenght<Person>());
            Console.WriteLine(new Doctor().GetPersonToStringLenght());
            Console.WriteLine(new Farmer().GetPersonToStringLenght());


            // same thing if you want to treat specific interfaces
            Console.WriteLine(new Lawyer().GetProfessionalToStringLenght<IProfessional>());
            Console.WriteLine(new Doctor().GetProfessionalToStringLenght<IProfessional>());
            Console.WriteLine(new Farmer().GetProfessionalToStringLenght<IProfessional>());

            #endregion


            // using Generics on classes can be also be very beneficial to avoid copying, for example:
            // let's say we're fetching results from a database.. or a cache, doesnt matter, and we have the same
            // result structure and the only thing that changes is the entities we retrieve...
            // we should have a generic ResultSet
            var currencyResult = new ResultSet<Currency>(new List<Currency> {
                new Currency {
                    Id = 1, 
                    Name = "USD", 
                    ShortName = "United States Dollar"
                }
            }, 1, 1);
            var languageResult = new ResultSet<Language>(new List<Language> {
                new Language {
                    Id = 1,
                    Name="Gallego",
                    Origin = "Galicia"
                }
            }, 1, 1);

            var language = languageResult.Items.FirstOrDefault();
            var currency = currencyResult.Items.FirstOrDefault();

            // let's make it more interesting
            var resolver = new ResultResolver();

            #region there's a way to handle default type instanciation
            // I wont be able to get a resultSet for a lawyer, that class does not an Item
            //var impossibleResult = resolver.GetFailureResult<Lawyer>();
            
            // next two will have no issue creating the response even though there was an error and 
            // we didnt initialized the Items generic list..
            var failureCurrencyResult = resolver.GetFailureResult<Currency>();
            var failureLanguageResult = resolver.GetFailureResult<Language>();
            #endregion

            // ref behavior remains the same with Generics, we can modify the value we send
            var newCurrency = new Currency { Id = 1, Name = "NIS", ShortName = "New Israeli Shekel" };
            resolver.CreateOrUpdateItem(ref newCurrency);
            Console.WriteLine("I'm not supposed to have a value on ShortName...");
        }
    }
}
