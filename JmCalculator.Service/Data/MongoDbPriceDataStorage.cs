using JmCalculator.Shared.Contracts;
using JmCalculator.Shared.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JmCalculator.Service.Data
{
    public class MongoDbPriceDataStorage : MongoDbDataSource<JmPrice>, IJmPriceDataStorage
    {
        

        [BsonIgnoreExtraElements]
        class JmPriceMongo : JmPrice
        {

        }

        public MongoDbPriceDataStorage(IJmCalculatorConfig config) : 
            base(config)
        {

        }
        public async Task<JmPrice> GetData(Expression<Func<JmPrice, bool>> expression)
        {
            var result = await table.FindAsync<JmPriceMongo>(expression); 

            var output = await result.FirstOrDefaultAsync();

            return output;
        }
    }
}
