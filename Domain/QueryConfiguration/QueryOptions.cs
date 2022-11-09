using System;
namespace Domain.QueryConfiguration
{
    public class QueryOptions
    {
        public const int LimitSize = 100;
        public string UserId { get; set; }

        public string SortBy { get; set; }

        public string Sort { get; set; }

        public int Limit { get; set; } = LimitSize;
    }
}

