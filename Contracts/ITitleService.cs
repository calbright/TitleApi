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
        public Task<IEnumerable<Title>> SearchByNameAsyc(string searchString);
        public Task<IEnumerable<OtherName>> GetOtherTitleByTitleIdAsync(int titleId);
    }
}
