using API.NewStories.Models;

namespace API.NewStories.Repository
{
    public interface INewStoriesRepository
    {
       public Task<List<int>>  GetNewStories();
        public Task<StoriesDetails> GetStorieData(int id);
    }
}
