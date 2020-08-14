using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        [Display(Name = "籍贯")]
        public string NativePlace { get; set; }

        [Display(Name = "民族")]
        public string Nation { get; set; }

        [Display(Name = "教育背景")]
        public string Education { get; set; }

        [Display(Name = "职称")]
        public string StemTitle { get; set; }

        [Display(Name = "社会职务")]
        public string SocialPosition { get; set; }

        public DateTime CareerDate { get; set; }

        public string WorkUnit { get; set; }

        [Display(Name = "职务")]
        public string WorkPost { get; set; }

        public string WorkCity { get; set; }

        public string WorkDistrict { get; set; }

        public string WorkAddress { get; set; }

        public string ResideCity { get; set; }

        public string ResideDistrict { get; set; }

        public string ResideAddress { get; set; }

        public string IdCardNumber { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string Sponsor1 { get; set; }

        public string Sponsor2 { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }

        public bool IsCandidate { get; set; }

        public bool IsActive { get; set; }

        public int BranchId { get; set; }

        public ICollection<CommitteeRanks> CommitteeRanks{get;}=new List<CommitteeRanks>();

        public ICollection<BranchRanks> BranchRanks{get;}=new List<BranchRanks>();

        public ICollection<MemberItemLog> ItemLogs { get; } = new List<MemberItemLog>();
        public ICollection<MemberStateLog> StateLogs { get; } = new List<MemberStateLog>();
    }
}