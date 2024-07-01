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
        public async Task<List<StoriesDetails>> GetNewStories(int pageID)
        {

            List<StoriesDetails> responseBody = new List<StoriesDetails>();
            List<int> responseStoriesDetail = null;
            HttpClient client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
            HttpResponseMessage response = await client.GetAsync("topstories.json?print=pretty");

            if (response.IsSuccessStatusCode)
            {
                responseStoriesDetail = await response.Content.ReadFromJsonAsync<List<int>>();
                int offset = pageID;
                int count = 10;
                List<string> stories = new List<string>();
                responseStoriesDetail = responseStoriesDetail.Select(a => a).Skip((offset - 1) * count).Take(offset * count).ToList();
                foreach (int item in responseStoriesDetail) {
                    StoriesDetails storyDetailResponse = await GetStorieData(item);
                    storyDetailResponse.StoryNumber = item;
                    responseBody.Add(storyDetailResponse);

                }

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
