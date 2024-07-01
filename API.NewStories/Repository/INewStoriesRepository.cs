using API.NewStories.Models;

namespace API.NewStories.Repository
{
    public interface INewStoriesRepository
    {
       public Task<List<StoriesDetails>>  GetNewStories(int pageID);
       
    }
}
