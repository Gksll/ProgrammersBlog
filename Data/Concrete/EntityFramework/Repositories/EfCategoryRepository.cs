using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Shared.Entities.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class CategoryRepository : EfEntityRepositoryBase<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
