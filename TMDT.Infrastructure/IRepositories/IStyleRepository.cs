using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IStyleRepository: IRepository<Style>
    {
        Task<List<Style>> CheckExistNameAsync(string styleNo, string styleName);
        Task<List<Style>> CheckExistByNo(string styleNo);
    }
}
