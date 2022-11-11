using System;
using Domain.GroupPosts;
using Domain.Groups;
using Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Contexts
{
    public interface IGroupPostContext
    {
        IMongoCollection<GroupPost> GroupPosts { get; }
        IMongoCollection<Group> Groups { get; }
    }

    public class GroupPostContext : IGroupPostContext
    {
        private readonly IMongoDatabase db;

        public GroupPostContext(IOptions<GroupPostConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<GroupPost> GroupPosts => db.GetCollection<GroupPost>("FbGroupPosts");
        public IMongoCollection<Group> Groups => db.GetCollection<Group>("FbGroups");


    }
}

