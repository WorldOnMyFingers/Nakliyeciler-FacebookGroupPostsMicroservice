using System;
using Application.Base;
using AutoMapper;
using Domain.GroupPosts;
using Domain.Repositories;
using Infrastructure.Repositories;
using MediatR;

namespace Application.GroupPosts.Queries.GetGroupPosts
{
    public class GetGroupPostsHandler : IRequestHandler<GetGroupPostsQuery, IEnumerable<GroupPostDto>>
    {
        private readonly IGroupUnitOfWork _groupUnitOfWork;
        private readonly IMapper _mapper;

        public GetGroupPostsHandler(IGroupUnitOfWork groupUnitOfWork, IMapper mapper)
        {
            _groupUnitOfWork = groupUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupPostDto>> Handle(GetGroupPostsQuery request, CancellationToken cancellationToken)
        {
            var entities = _groupUnitOfWork.GroupPostReadOnlyRepository.GetMultiple(request.QueryOptions);
            return _mapper.Map<IEnumerable<GroupPostDto>>(entities);
        }
    }
}

