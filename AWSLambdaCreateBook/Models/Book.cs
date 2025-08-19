using Amazon.DynamoDBv2.DataModel;

namespace AWSLambdaCreateBook.Models
{
    [DynamoDBTable("books")]
    public class Book
    {
        [DynamoDBHashKey]
        public string Id { get; set; } = default!;

        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        // Agrega más propiedades según tu estructura JSON
    }
}
