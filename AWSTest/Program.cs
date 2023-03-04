// See https://aka.ms/new-console-template for more information
using AWSTest.Services;
using AWSTest.Models;

// api reference - https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Using.API.html
// https://github.com/awsdocs/aws-doc-sdk-examples/tree/17544377ba8ae9470b25580a32d87e1ab3509d3f/dotnetv3/dynamodb
// .net documentation - https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/dynamodb-intro.html#dynamodb-intro-apis-document
Console.WriteLine("Hello, World!");
var dynamo = new DynamoService();
var success = await dynamo.AddSerialAsync("Serials", new SerialModel() { Attribution = "test1", Serial = 888, Orig = "{\"raw\":2}" });
Console.WriteLine(success);

var result = await dynamo.GetSerialAsync("Serials", "test1");
Console.WriteLine(result);
