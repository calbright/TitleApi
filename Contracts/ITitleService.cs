using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleApi.Models;
using TitleData.Models;

namespace TitleApi.Contracts
{
    public interface ITitleService
    {
        public Task<IEnumerable<Title>> GetTitlesAsync();
        public Task<IEnumerable<Title>> SearchByNameAsyc(SearchTitleModel model);
        public Task<IEnumerable<TitleGenreDetails>> GetGenresByTitleIdAsync(int titleId);
    }
}
