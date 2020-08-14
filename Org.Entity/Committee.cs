using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Committee
    {
        public int Id{get;set;}

        public string Name{get;set;}

        public string ShortName{get;set;}

        [Display(Name="成立日期")]
        public DateTime FoundDate{get;set;}

        [Display(Name="现任届次")]
        public int CurrentSequence{get;set;}

        public ICollection<Branch> Branches{get;} = new List<Branch>();
        public ICollection<CommitteeRanks> CommitteeRanks{get;} = new List<CommitteeRanks>();
    }
}
