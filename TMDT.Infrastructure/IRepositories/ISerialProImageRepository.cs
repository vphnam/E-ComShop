using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.IRepositories
{
    public interface ISerialProImageRepository: IRepository<SerialProImage>
    {
        Task<SerialProImage> GetRecordByNoAsync(string serialNo, string serialProImgNo);
        Task<IEnumerable<string>> GetImagesBySerialNo(string serialNo);
    }
}
