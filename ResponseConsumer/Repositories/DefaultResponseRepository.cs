using MongoDB.Driver;
using ResponseConsumer.Data;
using ResponseConsumer.Entities;
using ResponseConsumer.Extensions;
using ResponseConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponseConsumer.Repositories
{
    public class DefaultResponseRepository : IResponseRepository
    {
        private readonly ICatalogContext _context;

        public DefaultResponseRepository(ICatalogContext catalogContext)
        {
            _context = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task<bool> CreateOrUpdate(ResponseModel responseModel)
        {
            var response = responseModel.ToResponse();
            FilterDefinition<Response> filter = Builders<Response>.Filter.Eq(m => m.Id, response.Id);
            ReplaceOptions options = new ReplaceOptions { IsUpsert = true };

            var updateResult = await _context
                .Responses
                .ReplaceOneAsync(filter, response, options);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> CreateOrUpdateMany(ICollection<ResponseModel> responseModels)
        {
            List<WriteModel<Response>> bulkOps = new List<WriteModel<Response>>();

            var responses = responseModels.Select(r => r.ToResponse());
            try
            {
                await _context
                    .Responses
                    .InsertManyAsync(responses);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Documents insert failed with error: " + e.Message);
                return false;
            }
            return true;
        }

        public async Task<ICollection<ResponseModel>> GetAll()
        {
            var responses = await _context
                .Responses
                .Find(Builders<Response>.Filter.Empty)
                .ToListAsync();

            var responseModels = responses
                .Select(r => r.ToResponseModel())
                .ToList();

            return responseModels;
        }
    }
}
