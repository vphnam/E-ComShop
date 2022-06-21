using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<List<Product>> CheckExistNameAsync(string productNo, string productName);
    }
}
