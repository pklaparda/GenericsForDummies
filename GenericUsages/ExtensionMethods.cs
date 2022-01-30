using GenericUsages.Entities;
using GenericUsages.Interfaces;

namespace GenericUsages
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// This method applies on every type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetToStringLenght<T>(this T value)
        {
            return value.ToString().Length;
        }

        /// <summary>
        /// This method only applies on structs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetPrimitiveToStringLenght<T>(this T value) where T : struct
        {
            return value.ToString().Length;
        }

        /// <summary>
        /// This method only applies on classes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetObjectToStringLenght<T>(this T value) where T : class
        {
            return value.ToString().Length;
        }

        /// <summary>
        /// This method only applies on Person-based classes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetPersonToStringLenght<T>(this T value) where T : Person
        {
            return value.ToString().Length;
        }

        /// <summary>
        /// This method applies only on classes implementing IProfessional interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetProfessionalToStringLenght<T>(this T value) where T : IProfessional
        {
            return value.ToString().Length;
        }
    }
}
