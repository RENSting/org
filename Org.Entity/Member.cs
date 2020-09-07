using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Member
    {
        public int Id { get; set; }

        [Display(Name="姓名"), Required]
        public string Name { get; set; }

        [Display(Name="性别")]
        public Gender Gender { get; set; }

        [Display(Name="出生日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
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

        [Display(Name="参加工作时间")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime CareerDate { get; set; }

        [Display(Name = "工作单位")]
        public string WorkUnit { get; set; }

        [Display(Name = "职务")]
        public string WorkPost { get; set; }

        [Display(Name = "工作省市")]
        public string WorkCity { get; set; }

        [Display(Name = "工作区县")]
        public string WorkDistrict { get; set; }

        [Display(Name = "单位地址")]
        public string WorkAddress { get; set; }

        [Display(Name = "居住省市")]
        public string ResideCity { get; set; }

        [Display(Name = "居住区县")]
        public string ResideDistrict { get; set; }

        [Display(Name = "家庭地址")]
        public string ResideAddress { get; set; }

        [Display(Name = "身份证号"), Required, RegularExpression("^\\d{18}$")]
        public string IdCardNumber { get; set; }

        [Display(Name = "移动电话"), Required]
        public string MobilePhone { get; set; }

        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        [Display(Name = "入会介绍人1")]
        public string Sponsor1 { get; set; }

        [Display(Name = "入会介绍人2")]
        public string Sponsor2 { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }

        [Display(Name = "发展中")]
        public bool IsCandidate { get; set; }

        [Display(Name = "有效")]
        public bool IsActive { get; set; }

        [Display(Name = "所属支部")]
        public int BranchId { get; set; }

        public ICollection<CommitteeRanks> CommitteeRanks{get;}=new List<CommitteeRanks>();

        public ICollection<BranchRanks> BranchRanks{get;}=new List<BranchRanks>();

        public ICollection<MemberItemLog> ItemLogs { get; } = new List<MemberItemLog>();
        public ICollection<MemberStateLog> StateLogs { get; } = new List<MemberStateLog>();

        public Branch Branch{get;set;}
    }
}