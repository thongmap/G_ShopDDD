using G_ShopDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace G_ShopInfrastructure
{
    public class AllRepo<TEntity> : IAllRepo<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbset;
        private readonly GShopEntities _dbContext;
        public AllRepo()
        {
            _dbContext = new GShopEntities();
            _dbset = _dbContext.Set<TEntity>();
        }
        public AllRepo(GShopEntities dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<TEntity>();
        }
        protected IDbSet<TEntity> DbSet
        {
            get { return _dbset; }
        }
        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }
        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return @readonly
                ? DbSet.AsNoTracking().ToList()
                : DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }
    }
}
