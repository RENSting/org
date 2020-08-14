using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class Branch
    {
        public int Id{get;set;}

        public string Name{get;set;}

        public string ShortName{get;set;}

        public DateTime FoundDate{get;set;}

        [Display(Name="现任届次")]
        public int CurrentSequence{get;set;}

        public int CommitteeId{get;set;}

        public Committee Committee{get;set;}
        public ICollection<BranchRanks> BranchRanks{get;}=new List<BranchRanks>();
        public ICollection<Member> Members{get;}=new List<Member>();
    }
}