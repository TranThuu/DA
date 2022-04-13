using FlarumWebApp.Core.DataContexts;
using FlarumWebApp.Repository.IRepositories;
using FlarumWebApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private ILogActiveRepository _logActiveRepository;
        private ISavedPostRepository _savedPostRepository;

        public UnitOfWork(FlarumDbContext context)
        {
            SuperAweSomeProjectDbContext = context;
        }

        public FlarumDbContext SuperAweSomeProjectDbContext { get; }
        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(SuperAweSomeProjectDbContext);
        public IPostRepository PostRepository => _postRepository ??= new PostRepository(SuperAweSomeProjectDbContext);
        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(SuperAweSomeProjectDbContext);
        public ILogActiveRepository LogActiveRepository => _logActiveRepository ??= new LogActiveRepository(SuperAweSomeProjectDbContext);
        public ISavedPostRepository SavedPostRepository => _savedPostRepository ??= new SavedPostRepository(SuperAweSomeProjectDbContext);


        public int SaveChanges()
        {
            return SuperAweSomeProjectDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SuperAweSomeProjectDbContext.SaveChangesAsync();
        }

    }
}
