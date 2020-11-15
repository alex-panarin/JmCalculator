using JmCalculator.Shared.Contracts;
using MongoDB.Driver;
using System;

namespace JmCalculator.Service.Data
{
    public abstract class MongoDbDataSource<TModel> 
    {
        protected readonly IMongoCollection<TModel> table;
        public MongoDbDataSource(IJmCalculatorConfig  config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var client = new MongoClient(config.ConnectionString);
            var database = client.GetDatabase(config.Name);

            table = database.GetCollection<TModel>(typeof(TModel).Name);

            if (table == null)
                throw new ArgumentNullException(nameof(table));
        }
    }
}
