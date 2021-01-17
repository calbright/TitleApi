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
    public class AwardService : IAwardService
    {
        public async Task<IEnumerable<Award>> GetAwardsByTitleIdAsync(int titleId)
        {
            using (var db = new TitlesContext())
            {
                var results = await db.Awards.Where(a => a.TitleId == titleId).Select(a => new Award
                {
                    Id = a.Id,
                    TitleId = a.TitleId,
                    Award1 = a.Award1,
                    AwardWon = a.AwardWon,
                    AwardYear = a.AwardYear,
                    AwardCompany = a.AwardCompany
                }).ToListAsync();
                return results;
            }
        }
    }
}
