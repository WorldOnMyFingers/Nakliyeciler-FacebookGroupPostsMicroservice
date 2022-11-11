using System;
using Domain.Base;

namespace Domain.GroupPosts
{
    public class GroupPost : BaseEntity
    {
        public string Message { get; set; }
        public string UpdatedDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}

