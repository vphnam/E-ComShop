using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ISerialProductRepository: IRepository<SerialProduct>
    {
        Task<List<SerialProduct>> CheckUnique(string serialNo, string productNo, string sizeNo, string colorNo);
    }
}
