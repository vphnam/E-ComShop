using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class FeedbackViewModel
    {
        public long FeedbackNo { get; set; }
        public int? OrderNo { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }
    }
}
