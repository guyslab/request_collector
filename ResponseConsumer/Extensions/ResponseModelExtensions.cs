using ResponseConsumer.Entities;
using ResponseConsumer.Models;

namespace ResponseConsumer.Extensions
{
    public static class ResponseModelExtensions
    {
        public static Response ToResponse(this ResponseModel responseModel)
        {
            return new Response
            {
                Id = responseModel.Id,
                Base64Body = responseModel.Base64Body,
                CorrelationId = responseModel.CorrelationId,
                Priority = responseModel.Priority,
                StatusCode = responseModel.StatusCode,
                TimestampUtc = responseModel.TimestampUtc,
                Url = responseModel.Url
            };
        }
    }
}
