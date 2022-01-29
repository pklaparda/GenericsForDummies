using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUsages.Entities
{
    public class ResultSet<T> where T : Item
    {
        public ResultSet() { }
        public ResultSet(List<T> items, int pageSize, int pageNumber)
        {
            Items = items;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string ErrorStatus { get; set; }
    }
}
