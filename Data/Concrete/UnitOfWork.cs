using Data.Abstract;
using Data.Concrete.EntityFramework.Contexts;
using Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _ArticleRepository;
        private EfCategoryRepository _CategoryRepository;
        private EfCommentRepository _CommentRepository;
        private EfRoleRepository _RoleRepository;
        private EfUserRepository _UserRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        

        public IArticleRepository Articles => _ArticleRepository ?? new EfArticleRepository(_context);
        //Daha önce çağırılmamışsa tekrar new edip _context ile dönüyoruz

        public ICategoryRepository Categories => _CategoryRepository ?? new EfCategoryRepository(_context   );

        public ICommentRepository Comments => _CommentRepository ?? new EfCommentRepository(_context);

        public IRoleRepository Roles => _RoleRepository ?? new EfRoleRepository(_context);

        public IUserRepository Users => _UserRepository ?? new EfUserRepository(_context);

        

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
