using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TitleData.Models;
using System.Net;
using System.Net.Http;
using TitleApi.Contracts;
using System.Net.Http.Headers;
using TitleApi.Models;

namespace TitleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryLineController : ControllerBase
    {
        private readonly ILogger<StoryLineController> _logger;
        private readonly IStoryLineService _storyLineService;
        public StoryLineController(ILogger<StoryLineController> logger, IStoryLineService storyLineService)
        {
            _logger = logger;
            _storyLineService = storyLineService;
        }

        [HttpGet("/storyline/{titleId}")]
        public async Task<IEnumerable<StoryLine>> GetStoryLineByTitleIdAsync([FromRoute] int titleId)
        {
            var result = await _storyLineService.GetStoryLineByTitleIdAsync(titleId);
            return result;
        }
    }
}
