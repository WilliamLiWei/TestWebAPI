using Domains.BaseModel;
using Domains.IRespositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class EFBaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        private IEFUnitOfWork UnitOfWork { get; set; }

        public EFBaseRepository()
        {
           
        }

        public IQueryable<TEntity> Entities
        {
            get { return UnitOfWork.context.Set<TEntity>(); }
        }

        public int Insert(TEntity entity)
        {
            UnitOfWork.RegisterNew(entity);
            return UnitOfWork.Commit();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.RegisterNew(obj);
            }
            return UnitOfWork.Commit();
        }

        public int Delete(object id)
        {
            var obj = UnitOfWork.context.Set<TEntity>().Find(id);
            if (obj == null)
            {
                return 0;
            }
            UnitOfWork.RegisterDeleted(obj);
            return UnitOfWork.Commit();
        }

        public int Delete(TEntity entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterDeleted(entity);
            }
            return UnitOfWork.Commit();
        }

        public int Update(TEntity entity)
        {
            UnitOfWork.RegisterModified(entity);
            return UnitOfWork.Commit();
        }

        public TEntity GetByKey(object key)
        {
            return UnitOfWork.context.Set<TEntity>().Find(key);
        }
    }
}
