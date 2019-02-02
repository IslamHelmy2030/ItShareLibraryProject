using System;
using System.Threading.Tasks;
using Library.Repositories.Repository;

namespace Library.Repositories.UnitOfWork
{
    public interface IUnitOfWork<T>  where T : class
    {
        IRepository<T> Repo { get; }
        Task<int> SaveChanges();
    }
}