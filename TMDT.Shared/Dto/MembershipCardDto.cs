using System;

namespace TMDT.Shared.Dto
{
    public class MembershipCardDto
    {
        public string CardNo { get; set; }
        public string CustomerNo { get; set; }
        public int? RankNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Point { get; set; }
        public bool? Status { get; set; }

        public virtual CustomerDto CustomerNoNavigation { get; set; }
        public virtual CardRankDto RankNoNavigation { get; set; }
    }
}
