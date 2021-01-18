using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleApi.Contracts;
using TitleApi.Models;
using TitleData.Context;
using TitleData.Models;

namespace TitleApi.Services
{
    public class GenreService : IGenreService
    {
        public async Task<IEnumerable<TitleGenreDetails>> GetGenresByTitleIdAsync(int titleId)
        {
            using (var db = new TitlesContext())
            {
                var query = from tg in db.TitleGenres
                            join g in db.Genres on tg.GenreId equals g.Id
                            where tg.TitleId == titleId
                            select new TitleGenreDetails
                            {
                                Id = tg.Id,
                                Name = tg.Genre.Name
                            };
                return await query.ToListAsync();
            }
        }

    }
}
