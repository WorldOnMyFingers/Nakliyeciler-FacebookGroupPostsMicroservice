using System;
using FacebookGroupPostsMicroservice.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FacebookGroupPostsMicroservice.MongoDb
{
    public class FbGroupService
    {
        public readonly IMongoCollection<FbGroupPost> _fbGroupPosts;

        public FbGroupService(IOptions<DataAccess> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _fbGroupPosts = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<FbGroupPost>(options.Value.FbGroupPostsCollectionName);
        }

        public async Task<List<FbGroupPost>> Get() => await _fbGroupPosts.Find(_ => true).ToListAsync();

        public async Task<FbGroupPost> Get(string id) => await _fbGroupPosts.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateOne(FbGroupPost newPost) => await _fbGroupPosts.InsertOneAsync(newPost);

        public async Task CreateMany(List<FbGroupPost> newPosts) => await _fbGroupPosts.InsertManyAsync(newPosts);

        public async Task Update(string id, FbGroupPost updatePost) => await _fbGroupPosts.ReplaceOneAsync(p => p.Id == id, updatePost);

        public async Task Remove(string id) => await _fbGroupPosts.DeleteOneAsync(p => p.Id == id);
    }
}

