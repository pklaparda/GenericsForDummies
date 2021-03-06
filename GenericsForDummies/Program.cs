using GenericsForDummies.Responses;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace GenericsForDummies
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var httpCaller = new HttpCaller();

            var comments = await httpCaller.GetAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");
            var resC = new Response<Comment>(comments);

            Console.WriteLine("Response from JsonPlaceHolder - 1st Comment");
            Console.WriteLine(JsonSerializer.Serialize(resC.Items[0]));

            Console.WriteLine();

            var posts = await httpCaller.GetAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
            var resP = new Response<Post>(posts);

            Console.WriteLine("Response from JsonPlaceHolder - Last Post");
            Console.WriteLine(JsonSerializer.Serialize(resP.Items[^1]));

            Console.WriteLine();

            var onePost = await httpCaller.GetAsync<Post>("https://jsonplaceholder.typicode.com/posts/1");
            var resOneP = new Response<Post>(onePost);

            Console.WriteLine("Response from JsonPlaceHolder - Only One Post");
            Console.WriteLine(JsonSerializer.Serialize(resOneP.Items[0]));

            var carEntity = new GenericEntity<int>(123, "the best car ever");
            var devEntity = new GenericEntity<double>(15.21, "a weirdly identified developer");
            
            //var notAllowedEntity = new GenericEntity<string>("FX_123", "a not allowed thing for this generic class");






        }

        public class GenericEntity<T> where T : struct
        {
            public GenericEntity(T id, string description)
            {
                Id = id;
                Description = description;
            }
            public T Id { get; set; }
            public string Description { get; set; }
            public override string ToString()
            {
                return $"This generic entity represents {Description}, identified by {Id} (of type {typeof(T)})";
            }
        }


    }
}
