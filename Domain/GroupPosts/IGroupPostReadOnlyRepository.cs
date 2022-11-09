using System;
using Domain.Base;

namespace Domain.GroupPosts
{
    public interface IGroupPostReadOnlyRepository: IReadOnlyRepository<string, GroupPost>
    {
        
    }
}

