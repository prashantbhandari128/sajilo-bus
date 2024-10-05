using WebService.DataAccess.Context;
using WebService.DataAccess.Entities;
using WebService.DataAccess.Repository.Interface;

namespace WebService.DataAccess.Repository.Implementation
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
