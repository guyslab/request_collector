using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ResponseConsumer.Entities
{
    public class Response
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Url { get; set; }
        public byte Priority { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset TimestampUtc { get; set; }
        public short StatusCode { get; set; }
        public string Base64Body { get; set; }

        public string CorrelationId { get; set; }

        public Response()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
