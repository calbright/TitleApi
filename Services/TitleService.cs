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
    public class TitleService : ITitleService
    {
        public async Task<IEnumerable<Title>> GetTitlesAsync()
        {
            using (var db = new TitlesContext())
            {
                return await db.Title.ToListAsync();
            }
        }
        public async Task<IEnumerable<Title>> SearchByNameAsyc(SearchTitleModel model)
        {
            using (var db = new TitlesContext())
            {
                var results = await db.Title.Where(t => EF.Functions.Like(t.TitleName, "%" + model.TitleName + "%")).Select(t => new Title
                {
                    TitleId = t.TitleId,
                    TitleName = t.TitleName,
                    TitleNameSortable = t.TitleNameSortable,
                    TitleTypeId = t.TitleTypeId,
                    ReleaseYear = t.ReleaseYear,
                    ProcessedDateTimeUtc = t.ProcessedDateTimeUtc
                }).ToListAsync();
                return results;
            }
        }
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
