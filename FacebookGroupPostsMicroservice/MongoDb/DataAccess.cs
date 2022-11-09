using System;
namespace FacebookGroupPostsMicroservice.MongoDb
{
    public class DataAccess
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string FbGroupPostsCollectionName { get; set; } = string.Empty;
    }
}

