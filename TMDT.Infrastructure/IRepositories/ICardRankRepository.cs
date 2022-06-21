using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ICardRankRepository
    {
        Task<CardRank> GetRecordByNo(int no);
    }
}
