using System;
using System.Threading.Tasks;

namespace Template.SharedKernel.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
