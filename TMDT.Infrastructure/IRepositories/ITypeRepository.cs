using TMDT.Infrastructure.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using System.Collections.Generic;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ITypeRepository: IRepository<Type>
    {
        Task<List<Type>> CheckExistNameAsync(string typeNo, string typeName);
        Task<List<Type>> CheckExistByNo(string typeNo);
    }
}
