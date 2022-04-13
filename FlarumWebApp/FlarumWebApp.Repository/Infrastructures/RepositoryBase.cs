using FlarumWebApp.Core.BaseEntities;
using FlarumWebApp.ViewModels.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlarumWebApp.Core.DataContexts;
using Microsoft.EntityFrameworkCore;
using FlarumWebApp.Core.Enums;

namespace FlarumWebApp.Repository.Infrastructures
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IBase
    {
        protected readonly FlarumDbContext Context;
        protected DbSet<TEntity> DbSet;
        public RepositoryBase(FlarumDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return DbSet.Any(predicate);
        }

        public void Delete(TEntity entity, bool isDeleted = false)
        {
            var entityExisting = this.DbSet.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (entityExisting != null)
            {
                if (!isDeleted)
                {
                    entityExisting.Status = Status.IsDeleted;
                    this.Context.Entry(entityExisting).State = EntityState.Modified;
                    return;
                }
                this.DbSet.Remove(entityExisting);
                return;
            }
            throw new ArgumentNullException($"{entity.Id} was not found in the {typeof(TEntity)}");
        }

        public void DeleteByCondition(Func<TEntity, bool> condition, bool isDeleted = false)
        {
            var query = this.DbSet.Where(condition);
            foreach (var item in query)
            {
                if (!isDeleted)
                {
                    item.Status = Status.IsDeleted;
                    this.Context.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    this.DbSet.Remove(item);
                }
            }
        }

        public void DeleteById(int id, bool isDeleted = false)
        {
            var entityExisting = DbSet.Find(id);
            if (entityExisting != null)
            {
                if (!isDeleted)
                {
                    entityExisting.Status = Status.IsDeleted;
                    this.Context.Entry(entityExisting).State = EntityState.Modified;
                    return;
                }
                this.DbSet.Remove(entityExisting);
                return;
            }
            throw new ArgumentNullException($"{id} was not found in the {typeof(TEntity)}");
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> condition, bool isDeleted = false)
        {
            var query = this.DbSet.Where(condition);
            if (!isDeleted)
            {
                return query.Where(x => x.Status != Status.IsDeleted);
            }
            return query;
        }

        public IEnumerable<TEntity> GetAll(bool isDeleted = false)
        {
            if (!isDeleted)
            {
                return DbSet.Where(x => x.Status != Status.IsDeleted);
            }
            return DbSet.AsEnumerable();
        }

        public TEntity GetById(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public PagedVm<TEntity> GetPaging(Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, bool isDeleted = false, int pageIndex = 1, int pageSize = 10)
        {
            var query = this.DbSet.AsEnumerable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!isDeleted)
            {
                query = query.Where(x => x.Status != Status.IsDeleted);
            }

            int totalRows = query.Count();
            int totalPage = (int)Math.Ceiling((decimal)totalRows / pageSize);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PagedVm<TEntity>(query, pageIndex, pageSize, totalPage);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
