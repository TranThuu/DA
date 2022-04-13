using FlarumWebApp.Core.DataContexts;
using FlarumWebApp.Core.Entities;
using FlarumWebApp.Repository.Infrastructures;
using FlarumWebApp.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Repository.Repositories
{
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(FlarumDbContext context):base(context)
        {

        }
    }
}
