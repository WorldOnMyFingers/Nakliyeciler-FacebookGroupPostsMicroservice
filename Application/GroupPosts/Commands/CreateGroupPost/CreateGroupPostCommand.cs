using System;
using MediatR;

namespace Application.GroupPosts.Commands.CreateGroupPost
{
    public record CreateGroupPostCommand : IRequest<bool>
    {
        public IEnumerable<CreateGroupPostDto> CreateGroupPostDtos { get; set; }
    }
}

