using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDT.Shared.Dto
{
    public class FeedbackDto
    {
        public long FeedbackNo { get; set; }
        public int? OrderNo { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }
    }
}
