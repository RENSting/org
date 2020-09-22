using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Org.Entity;

namespace Org.Web.Models
{
    public class MemberDetailsViewModel
    {
        public int MemberId{get;set;}

        public Member MemberInfo{get;set;}

        public Branch BranchInfo{get;set;}

        public ICollection<RanksViewState> RankLogs{get;set;}

        public ICollection<MemberStateLog> StateLogs{get;set;}

        public ICollection<MemberItemLog> ItemLogs{get;set;}
    }

    /// <summary>
    /// 会员在委员会或者支部等基层组织的任职记录（履历）
    /// </summary>
    public class RanksViewState
    {
        [Display(Name="姓名")]
        public string MemberName{get;set;}

        /// <summary>
        /// “委员会”或者“支部”
        /// </summary>
        /// <value></value>
        [Display(Name="组织类型")]
        public string BoardType{get;set;}

        [Display(Name="任职记录Id")]
        public int MemberRankId { get; set; }

        [Display(Name="组织名称")]
        public string BoardName{get;set;}

        [Display(Name = "届次")]
        public int Sequence { get; set; }

        [Display(Name="职务")]
        public string Title { get; set; }

        [Display(Name="任职日期")]
        public DateTime AppointDate { get; set; }

        [Display(Name="已离任")]
        public bool IsRemoved { get; set; }

        [Display(Name="离任日期")]
        public DateTime RemoveDate { get; set; }
    }
}