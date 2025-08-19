using Amazon.DynamoDBv2.DataModel;
using System.Text.Json.Serialization;

namespace AWSLambdaCreateBook.Models
{
    [DynamoDBTable("books")]
    public class Book
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        [DynamoDBProperty("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [DynamoDBProperty("author")]
        [JsonPropertyName("author")]
        public string Author { get; set; } = default!;
        // Agrega más propiedades según tu estructura JSON
    }
}
