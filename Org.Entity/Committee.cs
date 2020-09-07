using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Committee
    {
        public int Id{get;set;}

        [Display(Name="委员会全称")]
        [MaxLength(200), Required]
        public string Name{get;set;}

        [Display(Name="简称"), MaxLength(10), Required]
        public string ShortName{get;set;}

        [Display(Name = "成立日期"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FoundDate{get;set;}

        [Display(Name="现任届次")]
        public int CurrentSequence{get;set;}

        public ICollection<Branch> Branches{get;} = new List<Branch>();
        public ICollection<CommitteeRanks> CommitteeRanks{get;} = new List<CommitteeRanks>();
    }
}
