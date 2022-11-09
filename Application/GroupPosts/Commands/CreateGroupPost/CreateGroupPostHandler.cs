using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Domain.GroupPosts;
using Domain.Repositories;
using MediatR;

namespace Application.GroupPosts.Commands.CreateGroupPost
{
    public class CreateGroupPostHandler : IRequestHandler<CreateGroupPostCommand, bool>
    {
        private readonly IGroupUnitOfWork _groupUnitOfWork;
        private readonly IMapper _mapper;

        public CreateGroupPostHandler(IGroupUnitOfWork groupUnitOfWork, IMapper mapper)
        {
            _groupUnitOfWork = groupUnitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateGroupPostCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<GroupPost> posts = _mapper.Map<IEnumerable<GroupPost>>(request.CreateGroupPostDtos);
            posts.ToList().ForEach(x => { x.CreatedAt = DateTime.Now; x.UpdatedAt = DateTime.Now; });
            try
            {
               await _groupUnitOfWork.GroupPostCommandRepository.CreateMultiple(posts);
            }
            catch
            {
                throw new Exceptions.ApplicationException("Failed to add new posts");
            }

            return true;
        }
    }
}

