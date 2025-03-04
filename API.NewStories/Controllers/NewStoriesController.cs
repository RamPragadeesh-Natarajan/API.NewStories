using API.NewStories.Models;
using API.NewStories.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace API.NewStories.Controllers
{
    [ApiController]
   
    public class NewStoriesController : ControllerBase
    {
        private readonly ILogger<NewStoriesController> _logger;
        private readonly INewStoriesRepository _newStoriesRepository;

        public NewStoriesController(ILogger<NewStoriesController> logger, INewStoriesRepository newStoriesRepository)
        {
            _logger = logger;
            _newStoriesRepository = newStoriesRepository;
        }

        [HttpGet]
        [Route("getNewStories/{id}")]
        public async Task<List<StoriesDetails>> Get(int id)
        {
            _logger.LogInformation("Executing get new stories");
            return await _newStoriesRepository.GetNewStories(id);
        }

       
    }
}
