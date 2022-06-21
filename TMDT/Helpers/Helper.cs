using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.Helpers
{
    public class Helper
    {
        public string GenerateId()
        {
            var ticks = DateTime.Now.Ticks;
            var guid = Guid.NewGuid().ToString();
            var uniqueSessionId = ticks.ToString() + '-' + guid; //guid created by combining ticks and guid (55 characters)
            return uniqueSessionId;
        }
    }
}
