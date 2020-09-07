using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Branch
    {
        public int Id{get;set;}

        [Display(Name="支部名称"), Required, MaxLength(200)]
        public string Name{get;set;}

        [Display(Name="简称"), Required, MaxLength(20)]
        public string ShortName{get;set;}
        
        [Display(Name="成立日期")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime FoundDate{get;set;}

        [Display(Name="现任届次")]
        public int CurrentSequence{get;set;}

        [Display(Name="所属委员会")]
        public int CommitteeId{get;set;}

        /// <summary>
        /// 所属委员会对象
        /// </summary>
        /// <value></value>
        public Committee Committee{get;set;}
        /// <summary>
        /// 班子成员
        /// </summary>
        /// <typeparam name="BranchRanks"></typeparam>
        /// <returns></returns>
        public ICollection<BranchRanks> BranchRanks{get;}=new List<BranchRanks>();
        /// <summary>
        /// 支部会员
        /// </summary>
        /// <typeparam name="Member"></typeparam>
        /// <returns></returns>
        public ICollection<Member> Members{get;}=new List<Member>();
    }
}