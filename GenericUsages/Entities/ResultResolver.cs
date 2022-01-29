using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUsages.Entities
{
    public class ResultResolver
    {
        public ResultSet<T> GetFailureResult<T>(string msg) where T : Item, new()
        {
            // there were some issues with the external source.. we need a default response
            var result = new ResultSet<T>();
            result.ErrorStatus = $"there was an issue with this {typeof(T).Name} item. {msg}";
            return result;
        }


        public void CreateOrUpdateItem<T>(ref T item) where T : Item, new()
        {
            // let's say we want to log only the base object..
            var itemCopy = new T();
            itemCopy.Id = item.Id;
            itemCopy.Name = item.Name;
            // for any weird reason we dont want the item with its custom values to move forward
            // so we return a new one with only the base props set.. dont worry, there's no boxing
            item = itemCopy;
        }
    }
}
