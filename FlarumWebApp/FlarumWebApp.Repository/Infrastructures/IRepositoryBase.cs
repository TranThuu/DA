using FlarumWebApp.Common.Constants;
using FlarumWebApp.Core.BaseEntities;
using FlarumWebApp.ViewModels.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Repository.Infrastructures
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IBase
    {
        IEnumerable<TEntity> GetAll(bool isDeleted = false);
        TEntity GetById(params object[] keyValues);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void DeleteById(int id, bool isDeleted = false);
        void Delete(TEntity entity, bool isDeleted = false);
        void DeleteByCondition(Func<TEntity, bool> condition, bool isDeleted = false);
        IEnumerable<TEntity> Find(Func<TEntity, bool> condition, bool isDeleted = false);
        bool Any(Func<TEntity, bool> predicate);

        PagedVm<TEntity> GetPaging(Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, bool isDeleted = false, int pageIndex = 1, int pageSize = Constant.PageSize);
    }

}