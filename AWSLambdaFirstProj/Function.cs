using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaFirstProj;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<Employee> FunctionHandler(string input, ILambdaContext context)
    {
        var dynamoDBcontext = new DynamoDBContext(new AmazonDynamoDBClient());
        var empObj = await dynamoDBcontext.LoadAsync<Employee>(input);
        return empObj;
    }

    public class Employee
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
