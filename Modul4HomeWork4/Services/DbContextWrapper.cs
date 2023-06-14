using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Services
{
    public class DbContextWrapper<T> : IDbContextWrapper<T>
    where T : DbContext
    {
        private readonly T _dbContext;

        public DbContextWrapper(
            IDbContextFactory<T> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public T DbContext => _dbContext;

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
