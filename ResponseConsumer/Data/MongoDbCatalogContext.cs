using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ResponseConsumer.Entities;
using ResponseConsumer.Options;

namespace ResponseConsumer.Data
{
    public class MongoDbCatalogContext : ICatalogContext
    {
        public MongoDbCatalogContext(IOptions<CatalogDatabaseOptions> options)
        {
            var settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Responses = database.GetCollection<Response>(settings.CollectionName);
        }

        public IMongoCollection<Response> Responses {get;}
    }
}
