using System;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class CommitteeRanks
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }

        [Display(Name = "届次")]
        public int Sequence { get; set; }

        public int MemberId { get; set; }

        public int SortOrder { get; set; }

        public string Title { get; set; }

        public DateTime AppointDate { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime RemoveDate { get; set; }

        public Committee Committee{get;set;}
        public Member Member{get;set;}
    }
}