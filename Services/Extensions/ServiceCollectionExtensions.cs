using Data.Abstract;
using Data.Concrete;
using Data.Concrete.EntityFramework.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstract;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork,UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        } 
    }
}
