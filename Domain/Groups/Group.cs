using System;
using Domain.Base;

namespace Domain.Groups
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

