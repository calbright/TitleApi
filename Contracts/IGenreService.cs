using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleApi.Models;
using TitleData.Models;

namespace TitleApi.Contracts
{
    public interface IGenreService
    {
        public Task<IEnumerable<TitleGenreDetails>> GetGenresByTitleIdAsync(int titleId);
    }
}
