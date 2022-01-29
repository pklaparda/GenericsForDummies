using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsForDummies
{
    public class Response<TData>
    {
        public Response(List<TData> items)
        {
            Items = items;
            Count = Items.Count;
        }

        public Response(TData item)
        {
            Items = new List<TData> { item };
            Count = 1;
        }

        public int Count { get; set; }
        public List<TData> Items {get;set;}
    }
}
