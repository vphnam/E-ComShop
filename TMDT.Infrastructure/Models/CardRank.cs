using System;
using System.Collections.Generic;

#nullable disable

namespace TMDT.Infrastructure.Models
{
    public partial class CardRank
    {
        public CardRank()
        {
            MembershipCards = new HashSet<MembershipCard>();
        }

        public int RankNo { get; set; }
        public string RankName { get; set; }

        public virtual ICollection<MembershipCard> MembershipCards { get; set; }
    }
}
