using System;
using Core.Ddd.Domain.Repositories;
using Template.Domain.Entities;

namespace Template.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product,Guid>
    {
    }
}
