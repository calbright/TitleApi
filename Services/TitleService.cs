using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
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
        public async Task<IEnumerable<Title>> SearchByNameAsyc(string searchString)
        {
            using (var db = new TitlesContext())
            {
                var titles = await db.Title.Where(t => EF.Functions.Like(t.TitleName, "%" + searchString + "%")).Select(t => new Title
                {
                    TitleId = t.TitleId,
                    TitleName = t.TitleName,
                    TitleNameSortable = t.TitleNameSortable,
                    TitleTypeId = t.TitleTypeId,
                    ReleaseYear = t.ReleaseYear,
                    ProcessedDateTimeUtc = t.ProcessedDateTimeUtc
                }).OrderBy(t => t.TitleNameSortable).ToListAsync();
                var ids = titles.Select(t => t.TitleId).ToList();
                if (ids.Any())
                {
                    foreach (var id in ids)
                    {
                        var participants = from tp in db.TitleParticipants
                                           join p in db.Participants on tp.Id equals p.Id
                                           where tp.TitleId == id
                                           select new TitleParticipant
                                           {
                                               Id = tp.Id,
                                               TitleId = tp.TitleId,
                                               ParticipantId = tp.ParticipantId,
                                               IsKey = tp.IsKey,
                                               RoleType = tp.RoleType,
                                               IsOnScreen = tp.IsOnScreen,
                                               Name = tp.Participant.Name
                                           };
                        var title = titles.Where(x => x.TitleId == id).FirstOrDefault();
                        foreach (var participant in participants)
                        {
                            title.TitleParticipants.Add(participant);
                        }
                        var titleGenres = from tg in db.TitleGenres
                                          join g in db.Genres on tg.GenreId equals g.Id
                                          where tg.TitleId == id
                                          select new TitleGenre
                                          {
                                              Id = tg.Id,
                                              Name = g.Name,
                                              GenreId = tg.GenreId
                                          };
                        foreach (var titleGenre in titleGenres)
                        {
                            title.TitleGenres.Add(titleGenre);
                        }
                        var storyLines = await db.StoryLines.Where(s => s.TitleId == id).Select(s => new StoryLine
                        {
                            TitleId = s.TitleId,
                            Type = s.Type,
                            Language = s.Language,
                            Description = s.Description
                        }).ToListAsync();
                        foreach (var storyLine in storyLines)
                        {
                            title.StoryLines.Add(storyLine);
                        }
                        var awards = await db.Awards.Where(a => a.TitleId == id).Select(a => new Award
                        {
                            TitleId = a.TitleId,
                            AwardWon = a.AwardWon,
                            AwardYear = a.AwardYear,
                            AwardCompany = a.AwardCompany,
                            Award1 = a.Award1
                        }).ToListAsync();
                        foreach (var award in awards)
                        {
                            title.Awards.Add(award);
                        }

                    }

                }
                return titles;
            }
        }
        public async Task<IEnumerable<OtherName>> GetOtherTitleByTitleIdAsync(int titleId)
        {
            using (var db = new TitlesContext())
            {
                var results = await db.OtherNames.Where(o => o.TitleId == titleId).Select(o => new OtherName
                {
                    TitleId = o.TitleId,
                    TitleNameLanguage = o.TitleNameLanguage,
                    TitleNameType = o.TitleNameType,
                    TitleNameSortable = o.TitleNameSortable,
                    TitleName = o.TitleName,
                    Id = o.Id
                }).OrderBy(o => o.TitleNameSortable).ToListAsync();
                return results;
            }
        }
        public async Task<IEnumerable<Participant>> GetPatricipantByTitleIdAsync(int titleId)
        {
            using (var db = new TitlesContext())
            {
                   var query = from tp in db.TitleParticipants
                            join p in db.Participants on tp.Id equals p.Id
                            where tp.TitleId == titleId
                            select new Participant
                            {
                                Id = p.Id,
                                Name = p.Name,
                                ParticipantType = p.ParticipantType
                            };
                return await query.ToListAsync();
            }
        }
    }
}
