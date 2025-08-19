using Amazon.DynamoDBv2.DataModel;
using System.Text.Json.Serialization;

namespace AWSLambdaCreateBook.Models
{
    [DynamoDBTable("books")]
    public class Book
    {
        [DynamoDBHashKey]
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("author")]
        public string Author { get; set; } = default!;
        // Agrega más propiedades según tu estructura JSON
    }
}
