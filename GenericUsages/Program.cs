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
        static void Main(string[] args)
        {
            #region generic methods

            // Generics can be used up to the highest-agnostic-type level
            // here we have some examples on putting limits to Generics:

            // method 'GetToStringLenght()' works for EVERY type
            /*INT*/     Console.WriteLine(1.GetToStringLenght());
            /*CHAR*/    Console.WriteLine('H'.GetToStringLenght());
            /*BOOLEAN*/ Console.WriteLine(false.GetToStringLenght());
            /*STRING*/  Console.WriteLine("Yechiel".GetToStringLenght());
            /*OBJECT*/  Console.WriteLine(new Lawyer().GetToStringLenght());


            // or you may want to limit the implementation to primitive (STRUCTS) types and don't allow everyone use a method
            // because maybe is not prepared to hadle any type..
            /*INT*/     Console.WriteLine(1.GetPrimitiveToStringLenght<int>()); 
            /*CHAR*/    Console.WriteLine('H'.GetPrimitiveToStringLenght());
            /*BOOLEAN*/ Console.WriteLine(false.GetPrimitiveToStringLenght<bool>());
            /*STRING*/  Console.WriteLine("Yechiel".GetPrimitiveToStringLenght());
            /*OBJECT*/  Console.WriteLine(new Lawyer().GetPrimitiveToStringLenght());


            // same thing if you just want to apply the logic to CLASSES..
            /*INT*/     Console.WriteLine(1.GetObjectToStringLenght<int>());
            /*CHAR*/    Console.WriteLine('H'.GetObjectToStringLenght<char>());
            /*BOOLEAN*/ Console.WriteLine(false.GetObjectToStringLenght<bool>());
            /*STRING*/  Console.WriteLine("Yechiel".GetObjectToStringLenght<string>());
            /*OBJECT*/  Console.WriteLine(new Lawyer().GetObjectToStringLenght<Lawyer>());


            // same thing if you want to treat specific classes (PERSON)
            /*CHAR*/   Console.WriteLine('H'.GetPersonToStringLenght());
            /*STRING*/ Console.WriteLine("Yechiel".GetPersonToStringLenght());
            /*PERSON*/ Console.WriteLine(new Lawyer().GetPersonToStringLenght<Person>());
            /*PERSON*/ Console.WriteLine(new Doctor().GetPersonToStringLenght());
            /*PERSON*/ Console.WriteLine(new Farmer().GetPersonToStringLenght());


            // same thing if you want to treat specific interfaces (IPROFESSIONAL)
            /*IPROFESSIONAL*/ Console.WriteLine(new Lawyer().GetProfessionalToStringLenght<IProfessional>());
            /*IPROFESSIONAL*/ Console.WriteLine(new Doctor().GetProfessionalToStringLenght<IProfessional>());
            /*IPROFESSIONAL*/ Console.WriteLine(new Farmer().GetProfessionalToStringLenght<IProfessional>());

            #endregion

            #region generic classes

            // using Generics on classes can be also be very beneficial to avoid copying, for example:
            // let's say we're fetching results from a database.. or a cache, doesnt matter, and we share the same
            // 'result structure' and the only thing that changes is the entities we retrieve...
            // we should have a generic ResultSet to return to the UI, through the wepapi.. and dont copy/paste resutls
            var currencyResult = new ResultSet<Currency>(new List<Currency> {
                new Currency {
                    Id = 1, 
                    Name = "USD", 
                    ShortName = "United States Dollar"
                },
                new Currency {
                    Id = 2,
                    Name = "ARG",
                    ShortName = "Peso Argentino"
                }
            }, 2, 1);
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

            // I wont be able to get a resultSet for a lawyer, that class IS NOT an Item based class
            //var impossibleResult = resolver.GetFailureResult<Lawyer>();

            // next two will have no issue creating the response even though there was an error and 
            // we didnt initialized the Items generic list..
            try
            {
                currencyResult.Items = null;
                currencyResult.Items.First();
            }
            catch (Exception ex)
            {
                var failureCurrencyResult = resolver.GetFailureResult<Currency>(ex.Message);
                Console.WriteLine(JsonSerializer.Serialize(failureCurrencyResult));
            }
            

            // ref behavior remains the same with Generics, we can modify the value we send
            var newCurrency = new Currency { Id = 1, Name = "NIS", ShortName = "New Israeli Shekel" };
            resolver.CreateOrUpdateItem(ref newCurrency);
            Console.WriteLine("I'm not supposed to have a value on ShortName...");

            #endregion
        }
    }
}
