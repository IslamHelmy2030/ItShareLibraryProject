using System;
using System.Threading.Tasks;
using Library.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Library.Repositories.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;

        public IRepository<T> Repo { get; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            Repo = new Repository<T>(context);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
