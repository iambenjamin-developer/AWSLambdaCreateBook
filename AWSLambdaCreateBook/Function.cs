using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AWSLambdaCreateBook.Models;
using System.Net;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaCreateBook;

public class Function
{
    private static readonly AmazonDynamoDBClient _dynamoDbClient = new();
    private static readonly DynamoDBContext _context = new(_dynamoDbClient);


    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            var book = JsonSerializer.Deserialize<Book>(request.Body);
            if (book == null)
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Body = JsonSerializer.Serialize(new { message = "Invalid book data." })
                };
            }

            book.Id = Guid.NewGuid().ToString();

            await _context.SaveAsync(book);

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.Created,
                Body = JsonSerializer.Serialize(book),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"Error: {ex.Message}");

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Body = JsonSerializer.Serialize(new { message = ex.Message }),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
    }
}
