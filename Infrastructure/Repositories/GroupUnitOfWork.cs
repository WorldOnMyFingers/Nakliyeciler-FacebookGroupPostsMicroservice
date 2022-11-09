using System;
using Domain.GroupPosts;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class GroupUnitOfWork : IGroupUnitOfWork
    {
        public GroupUnitOfWork(
        IGroupPostReadOnlyRepository postReadOnlyRepository,
        IGroupPostCommandRepository postCommandRepository)
        {
            GroupPostReadOnlyRepository = postReadOnlyRepository;
            GroupPostCommandRepository = postCommandRepository;
        }

        public IGroupPostReadOnlyRepository GroupPostReadOnlyRepository { get; }

        public IGroupPostCommandRepository GroupPostCommandRepository { get; }
    }
}

