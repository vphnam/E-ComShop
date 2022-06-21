using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class MembershipCard
    {
        public string CardNo { get; set; }
        public string CustomerNo { get; set; }
        public int RankNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Point { get; set; }
        public bool Status { get; set; }

        public virtual Customer CustomerNoNavigation { get; set; }
        public virtual CardRank RankNoNavigation { get; set; }
    }
}
