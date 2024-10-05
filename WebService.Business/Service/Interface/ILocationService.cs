using WebService.Business.DTO;
using WebService.Business.Result.Template.Operation;
using WebService.Business.Result.Template.Process;
using WebService.Business.Result.Template.Query;
using WebService.DataAccess.Entities;

namespace WebService.Business.Service.Interface
{
    public interface ILocationService
    {
        Task<QueryResultList<Location>> GetAllLocationsAsync();
        Task<QueryResult<Location>> GetLocationByIdAsync(Guid id);
        Task<OperationResult<Location>> AddLocationAsync(LocationDto locationDto);
        Task<OperationResult<Location>> UpdateLocationAsync(LocationDto locationDto);
        Task<ProcessResult> DeleteLocationAsync(Guid id);
    }
}
