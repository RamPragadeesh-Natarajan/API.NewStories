using API.NewStories.Models;
using API.NewStories.Repository;
using System.Net.Http;

namespace API.NewStories.Services
{
    public class NewStoriesRepository : INewStoriesRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NewStoriesRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<int>> GetNewStories()
        {
            List<int> responseBody = null;
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
            HttpResponseMessage response = await client.GetAsync("topstories.json?print=pretty");

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadFromJsonAsync<List<int>>();
                
            }
            return responseBody;
            
        }

        public async Task<StoriesDetails> GetStorieData(int id)
        {
            StoriesDetails responseBody = null;
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
            HttpResponseMessage response = await client.GetAsync($"item/{id}.json?print=pretty");
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadFromJsonAsync<StoriesDetails>();

            }
            return responseBody;
        }
    }
}
