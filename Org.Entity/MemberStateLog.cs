using System;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class MemberStateLog
    {
        public int Id{get;set;}

        public int MemberId{get;set;}

        public MemberState State{get;set;}

        public string SubCategory{get;set;}

        public string Description{get;set;}

        public DateTime StateDate{get;set;}

        public DateTime TimeStamp{get;set;}

        public Member Member{get;set;}
    }
}