using System;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Domain.GroupPosts;

namespace Application.Base
{
    [AutoMap(typeof(GroupPost), ReverseMap = true)]
    public class GroupPostDto
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string GroupId { get; set; }

        public string GroupName { get; set; }

        public string UpdatedDate  { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

