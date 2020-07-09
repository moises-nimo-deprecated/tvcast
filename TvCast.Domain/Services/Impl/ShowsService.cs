using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TvCast.Domain.Models;
using TvCast.Entity.Entities;
using TvCast.Entity.Repositories;

namespace TvCast.Domain.Services.Impl
{
    public class ShowsService : IShowsService
    {
        protected IMapper Mapper { get; set; }
        protected IShowsRepository ShowsShowsRepository { get; set; }
        public ShowsService(IMapper mapper, IShowsRepository showsRepository)
        {
            Mapper = mapper;
            ShowsShowsRepository = showsRepository;
        }
        
        public async Task<IEnumerable<ShowModel>> GetAsync(int page, int itemsPerPage)
        {
            var shows = await ShowsShowsRepository.GetAsync(page, itemsPerPage);
            return Mapper.Map<IEnumerable<ShowModel>>(shows);
        }
    }
}