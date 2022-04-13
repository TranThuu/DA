using FlarumWebApp.Core.DataContexts;
using FlarumWebApp.Repository.IRepositories;
using System.Threading.Tasks;

namespace FlarumWebApp.Repository.Infrastructures
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICommentRepository CommentRepository { get; }
        ILogActiveRepository LogActiveRepository { get; }
        IPostRepository PostRepository { get; }
        ISavedPostRepository SavedPostRepository { get; }
        FlarumDbContext SuperAweSomeProjectDbContext { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}