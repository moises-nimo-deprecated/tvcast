using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TvCast.Domain.TvMazeModels;
using TvCast.Entity.Entities;
using TvCast.Entity.Repositories;

namespace TvCast.Domain.Services.Impl
{
    public class TvMazeSavingService : ITvMazeSavingService
    {
        protected ICastRepository CastRepository { get; set; }
        protected IMapper Mapper { get; set; }
        public TvMazeSavingService(ICastRepository castRepository, IMapper mapper)
        {
            CastRepository = castRepository;
            Mapper = mapper;

        }
        public async Task<int> SaveAsync(TvMazeShow model)
        {
            var casts = Mapper.Map<IList<Casting>>(model);
            return await CastRepository.SaveRangeAsync(casts);
        }

        public async Task<long?> FindLastInsertedShowAsync()
        {
            return await CastRepository.FindLastInsertedShowAsync();
        }
    }
}