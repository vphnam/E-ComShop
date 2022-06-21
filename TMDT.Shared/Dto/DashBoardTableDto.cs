using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class DashBoardTableDto
    {
        public int ProcessStatusCode { get; set; }
        public string ProcessStatusName { get; set; }
        public int QuantityOrder { get; set; }
        public DashBoardTableDto(int processStatusCode, string processStatusName, int quantityOrder)
        {
            this.ProcessStatusCode = processStatusCode;
            this.ProcessStatusName = processStatusName;
            this.QuantityOrder = quantityOrder;
        }
        public DashBoardTableDto(int processStatusCode, string processStatusName)
        {
            this.ProcessStatusCode = processStatusCode;
            this.ProcessStatusName = processStatusName;
        }
    }
}
