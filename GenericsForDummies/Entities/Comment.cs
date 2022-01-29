using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsForDummies.Responses
{
    public class Comment
    {
        [JsonProperty(propertyName: "postId")]
        public int PostId { get; set; }
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }
        [JsonProperty(propertyName: "body")]
        public string Body { get; set; }
    }
}
