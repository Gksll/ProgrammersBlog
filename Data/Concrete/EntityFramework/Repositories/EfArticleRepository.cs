using Data.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public EfArticleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
