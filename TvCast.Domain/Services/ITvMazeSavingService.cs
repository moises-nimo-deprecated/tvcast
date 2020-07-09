using System.Threading.Tasks;
using TvCast.Domain.TvMazeModels;

namespace TvCast.Domain.Services
{
    public interface ITvMazeSavingService
    {
        Task<int> SaveAsync(TvMazeShow model);
        Task<long?> FindLastInsertedShowAsync();
    }
}