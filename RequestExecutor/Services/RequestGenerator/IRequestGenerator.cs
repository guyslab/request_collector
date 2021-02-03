using RequestExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
