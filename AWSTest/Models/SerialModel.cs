using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSTest.Models
{
    [DynamoDBTable("Serials")]
    internal class SerialModel
    {
        [DynamoDBHashKey]
        public string Attribution { get; set; }

        [DynamoDBProperty]
        public int Serial { get; set; }

        [DynamoDBProperty("orig")]
        public string Orig { get; set; }
    }
}
