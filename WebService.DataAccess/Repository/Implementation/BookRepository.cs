using WebService.DataAccess.Context;
using WebService.DataAccess.Entities;
using WebService.DataAccess.Repository.Interface;

namespace WebService.DataAccess.Repository.Implementation
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
