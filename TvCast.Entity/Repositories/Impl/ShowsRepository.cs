using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvCast.Entity.Entities;

namespace TvCast.Entity.Repositories.Impl
{
    public class ShowsRepository : IShowsRepository
    {
        protected TvCastDbContext DbContext { get; set; }
        public ShowsRepository(TvCastDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<IEnumerable<Show>> GetAsync(int page, int itemsPerPage)
        {
            var toSkip = (page - 1) * itemsPerPage;
            var query = DbContext.Shows
                .Include(i => i.Castings)
                .ThenInclude(i => i.Character)
                .Include(i => i.Castings.OrderByDescending(p => p.Person.Data.Birthday))
                .ThenInclude(i => i.Person);
            return await query.Skip(toSkip).Take(itemsPerPage).ToListAsync();
        }
    }
}