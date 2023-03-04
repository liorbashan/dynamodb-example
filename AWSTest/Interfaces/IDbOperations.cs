using AWSTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSTest.Interfaces
{
    internal interface ISerialOperations
    {
        public Task<bool> AddSerialAsync(string tableName, SerialModel data);
        public Task<SerialModel?> GetSerialAsync(string tableName, string attr);
    }
}
