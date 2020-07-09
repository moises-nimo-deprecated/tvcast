using System.Collections.Generic;
using System.Threading.Tasks;
using TvCast.Domain.Models;
using TvCast.Entity.Entities;

namespace TvCast.Domain.Services
{
    public interface IShowsService
    {
        Task<IEnumerable<ShowModel>> GetAsync(int page, int itemsPerPage);
    }
}