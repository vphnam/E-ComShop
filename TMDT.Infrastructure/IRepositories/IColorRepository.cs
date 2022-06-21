using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IColorRepository: IRepository<Color>
    {
        Task<List<Color>> CheckExistNameAsync(string colorNo, string colorName);
        Task<List<Color>> CheckExistByNo(string colorNo);
    }
}
