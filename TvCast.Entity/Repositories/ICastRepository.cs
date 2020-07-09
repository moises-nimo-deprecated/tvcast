using System.Collections.Generic;
using System.Threading.Tasks;
using TvCast.Entity.Entities;

namespace TvCast.Entity.Repositories
{
    public interface ICastRepository
    {
        Task<int> SaveRangeAsync(IEnumerable<Casting> entities);
        Task<long?> FindLastInsertedShowAsync();
    }
}