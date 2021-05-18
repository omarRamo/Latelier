using CatMash.MVC.DTO;
using CatMash.MVC.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatMash.MVC.BusinessLogic
{
    public class CatService : ICatService
    {
        private readonly ILogger<CatService> _logger;
        //private readonly IOptions<ApiConfiguration> _apiConfiguration;
        private HttpClient _httpClient;
        private readonly ApiConfiguration _apiConfiguration;

        public CatService(ILogger<CatService> logger, HttpClient httpClient, ApiConfiguration apiConfiguration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _apiConfiguration = apiConfiguration;
        }

        public async Task<CatsModel> GetCats()
        {
            
            var uri = $"{_apiConfiguration.ApiPath}/cats";
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return new CatsModel { Cats = new List<Tuple<CatPicture, CatPicture>>() };
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CatsModel>(content);
        }

        public async Task<Tuple<CatPicture, CatPicture>> GetCatsForVote()
        {
            var uri = $"{_apiConfiguration.ApiPath}/vote";
            var response = await _httpClient.GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Tuple<CatPicture, CatPicture>>(content);
        }

        public async Task SendVote(VoteModel vote)
        {
            var uri = $"{_apiConfiguration.ApiPath}/vote";

            var content = new StringContent(JsonConvert.SerializeObject(vote), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);


            response.EnsureSuccessStatusCode();
        }

    }
}
