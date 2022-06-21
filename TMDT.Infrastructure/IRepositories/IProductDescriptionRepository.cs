using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IProductDescriptionRepository: IRepository<ProductDescription>
    {
        Task<IReadOnlyList<ProductDescription>> GetListByProductNoAsync(string productNo);
        Task<ProductDescription> GetRecordByNoAsync(string productDescriptionNo, string productNo);
    }
}
