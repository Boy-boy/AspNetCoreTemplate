using Core.EntityFrameworkCore;
using Core.EntityFrameworkCore.Repositories;
using Template.Domain.Entities;
using Template.Domain.Repositories;

namespace Template.EntityFramework.Repositories
{
    public class ProductRepository : EfCoreRepository<TemplateDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<TemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
