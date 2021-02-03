using ResponseConsumer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResponseConsumer.Repositories
{
    public interface IResponseRepository
    {
        Task<bool> CreateOrUpdate(ResponseModel response);
        Task<bool> CreateOrUpdateMany(ICollection<ResponseModel> responses);
    }
}
