using Microsoft.EntityFrameworkCore.Storage;
using WebService.DataAccess.Context;
using WebService.DataAccess.Repository.Implementation;
using WebService.DataAccess.Repository.Interface;
using WebService.DataAccess.UnitOfWork.Interface;

namespace WebService.DataAccess.UnitOfWork.Implementation
{
    /// <summary>
    /// Represents the Unit of Work pattern implementation.
    /// It manages the repositories and handles database transactions.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private bool _disposed = false;

        //-----------[ Add repositories here ]----------
        public IBookRepository Books { get; }
        //----------------------------------------------

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            //----------[ Initialize repositories here ]----------
            Books = new BookRepository(_context);
            //----------------------------------------------------
        }

        public int Complete() => _context.SaveChanges();

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
