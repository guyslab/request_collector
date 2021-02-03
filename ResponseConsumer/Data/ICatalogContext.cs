using MongoDB.Driver;
using ResponseConsumer.Entities;

namespace ResponseConsumer.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Response> Responses { get; }
    }
}
