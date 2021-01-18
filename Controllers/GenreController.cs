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
    public class GenreController : ControllerBase
    {
        private readonly ILogger<TitleController> _logger;
        private readonly IGenreService _genreService;
        public GenreController(ILogger<TitleController> logger, IGenreService genreService)
        {
            _logger = logger;
            _genreService = genreService;
        }

        [HttpGet("/{titleId}")]
        public async Task<IEnumerable<TitleGenreDetails>> GetGenresByTitleIdAsync([FromRoute] int titleId)
        {
            var result = await _genreService.GetGenresByTitleIdAsync(titleId);
            return result;
        }
    }
}
