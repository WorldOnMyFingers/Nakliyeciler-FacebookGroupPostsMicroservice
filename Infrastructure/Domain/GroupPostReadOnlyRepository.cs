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

                var posts = _context.GroupPosts.AsQueryable();//.OrderByDescending(x => x.UpdatedDate).Take(options.Limit).ToList();
                var groups = _context.Groups.AsQueryable();
                var q = from post in posts
                        join fbGroup in groups
                        on post.Id. equals fbGroup.Id
                        select new
                        {
                            post,
                            Group = fbGroup
                        };
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

