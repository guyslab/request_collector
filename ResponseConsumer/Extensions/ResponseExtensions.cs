using ResponseConsumer.Entities;
using ResponseConsumer.Models;

namespace ResponseConsumer.Extensions
{
    public static class ResponseExtensions
    {
        public static ResponseModel ToResponseModel(this Response response)
        {
            return new ResponseModel
            {
                Id = response.Id,
                Base64Body = response.Base64Body,
                CorrelationId = response.CorrelationId,
                Priority = response.Priority,
                StatusCode = response.StatusCode,
                TimestampUtc = response.TimestampUtc,
                Url = response.Url
            };
        }
    }
}
