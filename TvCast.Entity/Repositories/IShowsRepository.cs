using System.Collections.Generic;
using System.Threading.Tasks;
using TvCast.Entity.Entities;

namespace TvCast.Entity.Repositories
{
    public interface IShowsRepository
    {
        Task<IEnumerable<Show>> GetAsync(int page, int itemsPerPage);
    }
}