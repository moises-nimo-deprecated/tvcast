using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvCast.Domain.Models;
using TvCast.Domain.Services;
using TvCast.Entity.Entities;

namespace TvCast.Api.Controllers
{
    [ApiController]
    [Route("/shows")]
    public class ShowsController
    {
        private IShowsService _showsService;

        public ShowsController(IShowsService showsService)
        {
            _showsService = showsService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ShowModel>> Get(int page = 1, int pageSize = 25)
        {
            //don't trick me
            if (page < 0)
                page = 0;
            //don't trick me part 2
            if (pageSize < 10)
                pageSize = 10;
            var result = await _showsService.GetAsync(page, pageSize);
            return result;
        }
    }
}