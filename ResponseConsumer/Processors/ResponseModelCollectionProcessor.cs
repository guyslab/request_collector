using ResponseConsumer.Models;
using ResponseConsumer.Options;
using ResponseConsumer.Repositories;
using System;
using System.Collections.Generic;

namespace ResponseConsumer.Processors
{
    public class ResponseModelCollectionProcessor : IProcessor<ICollection<ResponseModel>>
    {
        private readonly IResponseRepository _repo;
        private readonly CatalogDatabaseOptions _options;



        public bool Process(ICollection<ResponseModel> arg)
        {
            try
            {
                // insert to DB in parallel
                return _repo.CreateOrUpdateMany(arg).Result;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
