using Core.EntityFrameworkCore;
using Core.EntityFrameworkCore.Repositories;
using Template.Domain.Entities;
using Template.Domain.Repositories;

namespace Template.EntityFramework.Repositories
{
    public class PaymentRepository : EfCoreRepository<TemplateDbContext, Payment>, IPaymentRepository
    {
        public PaymentRepository(IDbContextProvider<TemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
