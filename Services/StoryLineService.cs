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
    public class StoryLineService : IStoryLineService
    {
        public async Task<IEnumerable<StoryLine>> GetStoryLineByTitleIdAsync(int titleId)
        {
            using (var db = new TitlesContext())
            {
                var results = await db.StoryLines.Where(s => s.TitleId == titleId).Select(s => new StoryLine
                {
                    Id = s.Id,
                    TitleId = s.TitleId,
                    Type = s.Type,
                    Language = s.Language,
                    Description = s.Description
                }).ToListAsync();
                return results;
            }
        }
    }
}
