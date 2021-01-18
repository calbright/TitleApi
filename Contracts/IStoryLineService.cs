using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleApi.Models;
using TitleData.Models;

namespace TitleApi.Contracts
{
    public interface IStoryLineService
    {
        public Task<IEnumerable<StoryLine>> GetStoryLineByTitleIdAsync(int titleId);
    }
}
