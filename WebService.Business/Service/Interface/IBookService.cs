using WebService.Business.DTO;
using WebService.Business.Result.Template.Operation;
using WebService.Business.Result.Template.Process;
using WebService.Business.Result.Template.Query;
using WebService.DataAccess.Entities;

namespace WebService.Business.Service.Interface
{
    public interface IBookService
    {
        Task<QueryResultList<Book>> GetAllBooksAsync();
        Task<QueryResult<Book>> GetBookByIdAsync(Guid id);
        Task<OperationResult<Book>> AddBookAsync(BookDto bookDto);
        Task<OperationResult<Book>> UpdateBookAsync(BookDto bookDto);
        Task<ProcessResult> DeleteBookAsync(Guid id);
    }
}
