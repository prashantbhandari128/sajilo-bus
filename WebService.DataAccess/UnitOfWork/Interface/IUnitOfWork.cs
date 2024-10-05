using Microsoft.EntityFrameworkCore.Storage;
using WebService.DataAccess.Repository.Interface;

namespace WebService.DataAccess.UnitOfWork.Interface
{
    /// <summary>
    /// Defines the contract for the Unit of Work pattern.
    /// It provides access to repositories and handles database transactions.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Repositories
        IBookRepository Books { get; }
        ILocationRepository Locations { get; }

        // Save changes
        int Complete();
        Task<int> CompleteAsync();

        // Transaction
        IDbContextTransaction BeginTransaction();
    }
}
