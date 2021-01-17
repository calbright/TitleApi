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
    public class AwardController : ControllerBase
    {
        private readonly ILogger<TitleController> _logger;
        private readonly IAwardService _awardService;
        public AwardController(ILogger<TitleController> logger, IAwardService awardService)
        {
            _logger = logger;
            _awardService = awardService;
        }

        [HttpPut("/{titleId}")]
        public async Task<IEnumerable<Award>> Put([FromRoute] int titleId)
        {
            var result = await _awardService.GetAwardsByTitleIdAsync(titleId);
            return result;
        }
    }
}
