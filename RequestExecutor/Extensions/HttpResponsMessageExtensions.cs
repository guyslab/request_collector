using RequestExecutor.Models;
using System;
using System.Net.Http;

namespace RequestExecutor.Extensions
{
    public static class HttpResponsMessageExtensions
    {
        public static ResponseModel ToResponseModel(this HttpResponseMessage res, RequestObjectModel req, string correlationId = "")
        {
            return new ResponseModel
            {
                Base64Body = Convert.ToBase64String(res.Content.ReadAsByteArrayAsync().Result),
                Priority = req.Priority,
                StatusCode = (short)res.StatusCode,
                TimestampUtc = DateTimeOffset.UtcNow,
                Url = req.Url,
                CorrelationId = correlationId
            };
        }
    }
}
