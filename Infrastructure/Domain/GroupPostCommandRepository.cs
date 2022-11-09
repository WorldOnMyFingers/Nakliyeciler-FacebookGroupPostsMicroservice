using System;
using Domain.GroupPosts;
using Infrastructure.Contexts;
using MongoDB.Driver;

namespace Infrastructure.Domain
{
    public class GroupPostCommandRepository : IGroupPostCommandRepository
    {
        private readonly IGroupPostContext _context;

        public GroupPostCommandRepository(IGroupPostContext context)
        {
            _context = context;
        }

        public async Task CreateMultiple(IEnumerable<GroupPost> entities)
        {
            try
            {
                await _context.GroupPosts.InsertManyAsync(entities);
            }
            catch (MongoWriteConcernException ex)
            {
                throw ex;
            }
        }

        public async Task Create(GroupPost entity)
        {
            try
            {
               await _context.GroupPosts.InsertOneAsync(entity);
            }
            catch (MongoWriteConcernException ex)
            {
                throw ex;
            }
        }

        public bool Update(string id, GroupPost entity)
        {
            try
            {
                ReplaceOneResult actionResult = _context.GroupPosts.ReplaceOne(post => post.Id == id, entity);
                return actionResult.IsAcknowledged && actionResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                DeleteResult actionResult = _context.GroupPosts.DeleteOne(post => post.Id == id);
                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


