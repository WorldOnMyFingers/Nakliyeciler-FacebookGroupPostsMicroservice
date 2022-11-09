using System;
using Application.Base;
using Domain.QueryConfiguration;
using MediatR;

namespace Application.GroupPosts.Queries.GetGroupPosts
{
    public class GetGroupPostsQuery : IRequest<IEnumerable<GroupPostDto>>
    {
        public QueryOptions QueryOptions { get; set; }
    }
}

