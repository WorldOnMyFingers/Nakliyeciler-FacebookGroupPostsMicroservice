using System;
using System.Reflection;
using Domain.GroupPosts;
using Domain.QueryConfiguration;
using Infrastructure.Contexts;
using MongoDB.Driver;

namespace Infrastructure.Domain
{
    public class GroupPostReadOnlyRepository : IGroupPostReadOnlyRepository
    {
        private readonly IGroupPostContext _context;

        public GroupPostReadOnlyRepository(IGroupPostContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupPost> GetMultiple(QueryOptions options)
        {
            try
            {
                return _context.GroupPosts.AsQueryable().OrderBy(post => post.CreatedAt).Take(options.Limit).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GroupPost Get(string id)
        {
            try
            {
                return _context.GroupPosts.Find(post => post.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

