// See https://aka.ms/new-console-template for more information
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Util;
using Microsoft.VisualBasic;
using System.Collections.Concurrent;


await class1.DeleteItems();


AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.EUWest1,
    Profile = new Profile("my-dev-profile")
};
AmazonDynamoDBClient _amazonDynamoDB = new(clientConfig);


//get 200 items
ApiPartitionKey partitionKey = new ApiPartitionKey("918968694466#WDlsaZ01RbVD#suppliers#bwind#");

var request = new QueryRequest
{
    TableName = Constants.Api.TableName,
    //IndexName = Constants.Api.ApiTableGsi1,
    KeyConditionExpression = $"{IrApiTableFields.PartitionKey} = :v_pk",
    ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                { ":v_pk", new (partitionKey.Value) },
            },
    Limit = 200,
    ProjectionExpression = $"{IrApiTableFields.PartitionKey},{IrApiTableFields.SortKey}"
};

var response = await _amazonDynamoDB.QueryAsync(request);

////delete items
//var table = Table.LoadTable(_amazonDynamoDB, Constants.Api.TableName);

//if (response.Items.Count > 0)
//{
//    var batchWrite = table.CreateBatchWrite();
//    foreach (var item in response.Items)
//    {
//        batchWrite.AddItemToDelete(new Document(item);
//    }
//   var delrespo = await batchWrite.ExecuteAsync();
//}


Console.WriteLine(response.ToString());









public record struct ApiPartitionKey(string Value);

public static class Constants
{
    public static class Api
    {
        public const string TableName = "ir-api";
        public const string ApiTableGsi1 = "gsi1";
    }
}

public struct IrApiTableFields
{
    public const string PartitionKey = "pk";
    public const string SortKey = "sk";
    public const string Index1SortKey = "gsi1sk";
    public const string EntityType = "et";
    public const string JsonEntity = "jent";
    public const string BinaryEntity = "bent"; // dynamodb reserved words contains ie. blob and binary
}





//string updateBatch = $"DELETE FROM \"ir-api\" WHERE \"pk\" = \"918968694466#WDlsaZ01RbVD#suppliers#bwind#\"";
//var statements = new List<BatchStatementRequest>
//            {
//                new BatchStatementRequest
//                {
//                    Statement = updateBatch,
//                    //Parameters = new List<AttributeValue>
//                    //{
//                    //    new AttributeValue { S = "918968694466#WDlsaZ01RbVD#suppliers#bwind#" },
//                    //},
//                }
//            };

//var response = await Client.BatchExecuteStatementAsync(new BatchExecuteStatementRequest
//{
//    Statements = statements,
//});