using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using AWSTest.Interfaces;
using AWSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSTest.Services
{
    internal class DynamoService : ISerialOperations
    {
        private AmazonDynamoDBClient _client { get; set; }
        public DynamoService()
        {
            var config = new AmazonDynamoDBConfig()
            {
                ServiceURL = "http://localhost:8000",
                UseHttp = true
            };
            _client = new AmazonDynamoDBClient("3cmkpt", "6qgsdp", config);
        }

        public async Task<bool> AddSerialAsync(string tableName, SerialModel data)
        {           
            var item = new Dictionary<string, AttributeValue>
            {
                ["Attribution"] = new AttributeValue { S = data.Attribution },
                ["Serial"] = new AttributeValue { N = data.Serial.ToString() },
                ["orig"] = new AttributeValue { S = data.Orig }
            };

            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = item
            };
            try
            {
                var response = await _client.PutItemAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            
        }

        public async Task<SerialModel?> GetSerialAsync(string tableName, string attr)
        {
            SerialModel? serialModel = null;
            var key = new Dictionary<string, AttributeValue>
            {
                ["Attribution"] = new AttributeValue { S = attr }
            };

            var request = new GetItemRequest
            {
                Key = key,
                TableName = tableName,
            };

            try
            {
                var response = await _client.GetItemAsync(request);
                if (response != null && response.Item != null)
                {
                    var doc = Document.FromAttributeMap(response.Item);
                    serialModel = new SerialModel()
                    {
                        Attribution = doc["Attribution"],
                        Serial = int.TryParse(doc["Serial"], out var val) ? val : 0,
                        Orig = doc["orig"]
                    };
                }
                return serialModel;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
