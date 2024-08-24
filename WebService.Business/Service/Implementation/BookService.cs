using WebService.Business.Service.Interface;
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
    }
}
