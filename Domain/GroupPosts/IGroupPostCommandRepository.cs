using System;
using Domain.Base;

namespace Domain.GroupPosts
{
    public interface IGroupPostCommandRepository : ICommandRepository<string, GroupPost>
    {
        Task CreateMultiple(IEnumerable<GroupPost> entities);
    }
}

