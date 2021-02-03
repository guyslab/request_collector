using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestExecutor.Models
{
    public class ResponseModel: RequestObjectModel
    {
        public DateTimeOffset TimestampUtc { get; set; }
        public short StatusCode { get; set; }
        public string Base64Body { get; set; }

        public string CorrelationId { get; set; }
    }
}
