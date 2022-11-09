using System;
using Domain.GroupPosts;

namespace Domain.Repositories
{
    public interface IGroupUnitOfWork
    {
        IGroupPostReadOnlyRepository GroupPostReadOnlyRepository { get; }
        IGroupPostCommandRepository GroupPostCommandRepository { get; }
    }
}

