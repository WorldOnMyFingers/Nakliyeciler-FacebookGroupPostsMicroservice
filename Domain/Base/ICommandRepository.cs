using System;
namespace Domain.Base
{
    public interface ICommandRepository<T, TEntity>
    {
        Task Create(TEntity entity);

        bool Update(T id, TEntity entity);

        bool Delete(T id);
    }
}

