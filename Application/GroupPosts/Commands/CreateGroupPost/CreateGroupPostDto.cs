using System;
using System.Text.RegularExpressions;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Domain.GroupPosts;

namespace Application.GroupPosts.Commands.CreateGroupPost
{
    [AutoMap(typeof(GroupPost), ReverseMap = true)]
    public class CreateGroupPostDto
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string UpdatedDate { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public CreateGroupPostDto()
        {
        }

        public CreateGroupPostDto(CreateGroupPostDto createPostDto)
        {
            Message = createPostDto.Message;
            UpdatedDate = createPostDto.UpdatedDate;
        }
    }
}

