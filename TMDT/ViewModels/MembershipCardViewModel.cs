using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels
{
    public class MembershipCardViewModel
    {
        public string CardNo { get; set; }
        public string CustomerNo { get; set; }
        public int? RankNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Point { get; set; }
        public bool? Status { get; set; }
    }
}
