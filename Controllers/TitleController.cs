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
    public class TitleController : ControllerBase
    {
        private readonly ILogger<TitleController> _logger;
        private readonly ITitleService _titleService;
        public TitleController(ILogger<TitleController> logger, ITitleService titleService)
        {
            _logger = logger;
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Title>> Get()
        {
            var result = await _titleService.GetTitlesAsync();
            return result;
        }
        [HttpPut]
        public async Task<IEnumerable<Title>> Put([FromBody] SearchTitleModel model)
        {
            var result = await _titleService.SearchByNameAsyc(model);
            return result;
        }
        [HttpPut("/genre/{titleId}")]
        public async Task<IEnumerable<TitleGenreDetails>> Put([FromRoute] int titleId)
        {
            var result = await _titleService.GetGenresByTitleIdAsync(titleId);
            return result;
        }
    }
}
