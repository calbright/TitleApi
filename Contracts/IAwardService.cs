using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleApi.Models;
using TitleData.Models;

namespace TitleApi.Contracts
{
    public interface IAwardService
    {
        public Task<IEnumerable<Award>> GetAwardsByTitleIdAsync(int titleId);
       
    }
}
