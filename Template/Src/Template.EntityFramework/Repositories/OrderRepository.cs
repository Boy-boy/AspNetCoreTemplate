using Core.EntityFrameworkCore;
using Core.EntityFrameworkCore.Repositories;
using Template.Domain.Entities;
using Template.Domain.Repositories;

namespace Template.EntityFramework.Repositories
{
    public class OrderRepository : EfCoreRepository<TemplateDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<TemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
