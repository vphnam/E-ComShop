using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDT.Infrastructure.Base;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Models;

namespace TMDT.Infrastructure.Repositories
{
    public class SerialProImageRepository: Repository<SerialProImage>, ISerialProImageRepository 
    {
        public SerialProImageRepository(IConfiguration config):base(config)
        {

        }

        public async Task<IEnumerable<string>> GetImagesBySerialNo(string serialNo)
        {
            var list = await _dbContext.SerialProImages.Where(n => n.SerialNo == serialNo).ToListAsync();
            return list.Select(n => n.ProductImageUrl);
        }

        public async Task<SerialProImage> GetRecordByNoAsync(string serialNo, string serialProImgNo)
        {
            return await _dbContext.SerialProImages.FindAsync(serialNo, serialProImgNo);
        }
    }
}
