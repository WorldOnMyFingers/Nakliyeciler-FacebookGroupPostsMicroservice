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

                var posts = _context.GroupPosts;//.AsQueryable();//.OrderByDescending(x => x.UpdatedDate).Take(options.Limit).ToList();
                var groups = _context.Groups;//.AsQueryable();

                var q = from post in posts.AsQueryable()
                        join fbGroup in groups.AsQueryable() on
                            post.GroupId equals fbGroup.Id
                        
                        select new
                        {
                            post,
                            Group = fbGroup
                        };

                if (options.Tags == null || !options.Tags.Any())
                    q = q.Where(x => options.Tags.All(y => x.post.Tags.Contains(y)));
                    //q = q.Where(x => x.post.Tags.Any(y => y == "Mersin"));

                if (options.Since != null)
                    q = q.Where(x => x.post.UpdatedDate > options.Since);

                var result = q.OrderByDescending(x => x.post.UpdatedDate).ToList();//.Take(options.Limit);

                var listOfGroupDto = result.Select(x => new GroupPost
                {
                    Id = x.post.Id,
                    Message = x.post.Message,
                    GroupId = x.post.GroupId,
                    GroupName = x.Group.Name,
                    Tags = x.post.Tags,
                    UpdatedDate = x.post.UpdatedDate,
                    CreatedAt = x.post.CreatedAt,
                    UpdatedAt = x.post.UpdatedAt
                });
                return listOfGroupDto;
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

