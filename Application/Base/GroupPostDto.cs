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

        [Ignore]
        public string FbGroupId => Id.Split('_')[0];

        public string Message { get; set; }

        public string UpdatedDate  { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

