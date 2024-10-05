using WebService.Business.DTO;
using WebService.Business.Result.Template.Operation;
using WebService.Business.Result.Template.Process;
using WebService.Business.Result.Template.Query;
using WebService.Business.Service.Interface;
using WebService.DataAccess.Entities;
using WebService.DataAccess.UnitOfWork.Interface;

namespace WebService.Business.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<QueryResultList<Book>> GetAllBooksAsync()
        {
            try
            {
                var books = await _unitOfWork.Books.ListAsync();
                return new QueryResultList<Book>(true, "Books fetched successfully.", books);
            }
            catch (Exception ex)
            {
                return new QueryResultList<Book>(false, ex.Message, null);
            }
        }

        public async Task<QueryResult<Book>> GetBookByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new QueryResult<Book>(false, "Invalid book ID.", null);
            }
            try
            {
                var book = await _unitOfWork.Books.FindAsync(id);
                return book != null
                    ? new QueryResult<Book>(true, "Book fetched successfully.", book)
                    : new QueryResult<Book>(false, $"Book with ID {id} not found.", null);
            }
            catch (Exception ex)
            {
                return new QueryResult<Book>(false, ex.Message, null);
            }
        }

        public async Task<OperationResult<Book>> AddBookAsync(BookDto bookDto)
        {
            try
            {
                var book = new Book
                {
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    PublishedDate = bookDto.PublishedDate,
                    ISBN = bookDto.ISBN,
                    Price = bookDto.Price,
                };
                await _unitOfWork.Books.InsertAsync(book);
                var rowInserted = await _unitOfWork.CompleteAsync();
                if (rowInserted == 0)
                {
                    return new OperationResult<Book>(false, "Book failed to save.", rowInserted, null);
                }
                return new OperationResult<Book>(true, "Book saved successfully.", rowInserted, book);
            }
            catch (Exception ex)
            {
                return new OperationResult<Book>(false, $"Exception Occurred : {ex.Message}", 0, null);
            }
        }
        public async Task<OperationResult<Book>> UpdateBookAsync(BookDto bookDto)
        {
            try
            {
                var book = new Book
                {
                    Id = bookDto.Id,
                    Title = bookDto.Title,
                    Author = bookDto.Author,
                    PublishedDate = bookDto.PublishedDate,
                    ISBN = bookDto.ISBN,
                    Price = bookDto.Price,
                };
                _unitOfWork.Books.Update(book);
                var rowInserted = await _unitOfWork.CompleteAsync();
                if (rowInserted == 0)
                {
                    return new OperationResult<Book>(false, $"Book with ID {bookDto.Id} not found.", 0, null);
                }
                return new OperationResult<Book>(true, "Book updated successfully.", rowInserted, book);
            }
            catch (Exception ex)
            {
                return new OperationResult<Book>(false, $"Exception Occurred : {ex.Message}", 0, null);
            }
        }

        public async Task<ProcessResult> DeleteBookAsync(Guid id)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var book = await _unitOfWork.Books.FindAsync(id);
                    if (book == null)
                    {
                        return new ProcessResult(false, $"{id} : Book not found.");
                    }
                    _unitOfWork.Books.Delete(book);
                    await _unitOfWork.CompleteAsync();
                    transaction.Commit();
                    return new ProcessResult(true, $"{id} : Book deleted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ProcessResult(false, $"Exception Occurred : {ex.Message}.");
                }
            }
        }
    }
}
