using Microsoft.AspNetCore.Mvc;

namespace TvCast.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        ///     Performs a redirect to the swagger documentation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedirectResult Get()
        {
            return RedirectPermanent("/swagger/");
        }
    }
}