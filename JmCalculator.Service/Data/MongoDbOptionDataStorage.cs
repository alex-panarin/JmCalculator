using JmCalculator.Shared.Contracts;
using JmCalculator.Shared.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JmCalculator.Service.Data
{
    public class MongoDbOptionDataStorage : MongoDbDataSource<JmOption>, IJmOptionDataStorage
    {
        [BsonIgnoreExtraElements]
        class JmOptionMongo : JmOption
        {

        }
        public MongoDbOptionDataStorage(IJmCalculatorConfig config) :
            base(config)
        {

        }
        public async Task<IEnumerable<JmOption>> GetData(Expression<Func<JmOption, bool>> expression)
        {
             var options = await table.FindAsync<JmOptionMongo>(expression);

            return await options.ToListAsync();
        }

    }
}
