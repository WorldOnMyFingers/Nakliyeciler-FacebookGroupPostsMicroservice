using System;
using Domain.Base;

namespace Domain.GroupPosts
{
    public class GroupPost : BaseEntity
    {
        public string Message { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public List<string> Tags { get; set; }
    }
}

