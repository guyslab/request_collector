using RequestExecutor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestExecutor.Services
{
    public interface IRequestGenerator
    {
        /// <summary>
        /// Generate multiple request objects
        /// </summary>
        /// <param name="objectsCount"></param>
        /// <returns></returns>
        Task<IEnumerable<RequestObjectModel>> GenerateMany(int objectsCount);
    }
}
