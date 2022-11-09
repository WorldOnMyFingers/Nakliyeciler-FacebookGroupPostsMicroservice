using System;
using Domain.QueryConfiguration;

namespace Domain.Base
{
    public interface IReadOnlyRepository<T, TEntity>
    {
        IEnumerable<TEntity> GetMultiple(QueryOptions options);

        TEntity Get(T id);
    }
}

