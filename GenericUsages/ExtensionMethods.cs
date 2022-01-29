using GenericUsages.Entities;
using GenericUsages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUsages
{
    public static class ExtensionMethods
    {
        public static int GetToStringLenght<TValue>(this TValue value)
        {
            return value.ToString().Length;
        }

        public static int GetPrimitiveToStringLenght<TValue>(this TValue value) where TValue : struct
        {
            return value.ToString().Length;
        }

        public static int GetObjectToStringLenght<TValue>(this TValue value) where TValue : class
        {
            return value.ToString().Length;
        }

        public static int GetPersonToStringLenght<TValue>(this TValue value) where TValue : notnull, Person
        {
            return value.ToString().Length;
        }

        public static int GetProfessionalToStringLenght<TValue>(this TValue value) where TValue : IProfessional
        {
            return value.ToString().Length;
        }
    }
}
