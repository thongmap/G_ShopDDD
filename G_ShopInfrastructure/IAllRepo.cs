using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace G_ShopInfrastructure
{
    public interface IAllRepo<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
    }
}
