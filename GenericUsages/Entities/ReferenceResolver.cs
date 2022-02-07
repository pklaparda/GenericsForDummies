using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericUsages.Entities
{
    public class ReferenceResolver
    {
        /// <summary>
        /// Create or update, will log the RECEIVED object and return a NEW object with the BASE props only.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void LogAndReturnBaseValuesOnly<T>(ref T item) where T : Item, new()
        {
            Console.WriteLine($"logging item before modifying it: {JsonSerializer.Serialize(item)}");
            
            var itemCopy = new T();
            itemCopy.Id = item.Id;
            itemCopy.Name = item.Name;
            // for any weird reason we dont want the item with its custom values to move forward
            // so we return a new one with only the base props set.. dont worry, there's no boxing
            item = itemCopy;
            Console.WriteLine($"logging item  after modifying it: {JsonSerializer.Serialize(item)}");
        }
    }
}
