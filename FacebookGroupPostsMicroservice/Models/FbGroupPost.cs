using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FacebookGroupPostsMicroservice.Models
{
    public class FbGroupPost
    {
        [BsonId]
        public string Id { get; set; }
        public string Message { get; set; }
        public string UpdatedDate { get; set; }
        public string FbGroupId { get; set; }
    }
}

