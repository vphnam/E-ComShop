using System.Collections.Generic;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ISizeRepository : IRepository<Size>
    {
        Task<List<Size>> CheckExistNameAsync(string sizeNo,string sizeName);
        Task<List<Size>> CheckExistByNo(string sizeNo);
    }
}
