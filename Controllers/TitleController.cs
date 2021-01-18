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
        [HttpGet("/titles")]
        public async Task<IEnumerable<Title>> GetAllTitles()
        {
            var result = await _titleService.GetTitlesAsync();
            return result;
        }
        [HttpGet("/title/{searchstring}")]
        public async Task<IEnumerable<Title>> GetByTitle([FromRoute] string searchstring)
        {
            var result = await _titleService.SearchByNameAsyc(searchstring);
            return result;
        }
        [HttpGet("/otherName/{titleId}")]
        public async Task<IEnumerable<OtherName>> GetOtherTitleByTitleId([FromRoute] int titleId)
        {
            var result = await _titleService.GetOtherTitleByTitleIdAsync(titleId);
            return result;
        }
    }
}
