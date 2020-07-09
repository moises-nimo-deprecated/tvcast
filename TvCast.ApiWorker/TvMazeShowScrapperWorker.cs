using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TvCast.Domain.Services;
using TvCast.Domain.TvMazeModels;

namespace TvCast.ApiWorker
{
    public class TvMazeShowScrapperWorker : BackgroundService
    {
        private readonly ILogger<TvMazeShowScrapperWorker> _logger;
        private readonly ITvMazeSavingService _tvMazeSavingService;

        public TvMazeShowScrapperWorker(ILogger<TvMazeShowScrapperWorker> logger, ITvMazeSavingService tvMazeSavingService)
        {
            _logger = logger;
            _tvMazeSavingService = tvMazeSavingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var lastInserted = await _tvMazeSavingService.FindLastInsertedShowAsync();
            while (!stoppingToken.IsCancellationRequested)
            {
                if (!lastInserted.HasValue)
                    lastInserted = 1;
                else
                    lastInserted++;
                
                var client = new HttpClient();
                var responseMessage = await client.GetAsync($"http://api.tvmaze.com/shows/{lastInserted}?embed=cast");
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    var tvMazeShow =  JsonConvert.DeserializeObject<TvMazeShow>(content, new JsonSerializerSettings
                    {
                        DateFormatString = "yyyy-MM-dd"
                    });
                    var value = await _tvMazeSavingService.SaveAsync(tvMazeShow);
                    _logger.LogInformation($"Added a new show {tvMazeShow.Id} - {tvMazeShow.Name}");    
                }
                else
                {
                    _logger.LogInformation($"Could not find a show with the id {lastInserted}");
                }
                
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}