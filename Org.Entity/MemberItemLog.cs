using System;
using System.ComponentModel.DataAnnotations;

namespace Org.Entity
{
    public class MemberItemLog
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string ItemName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Remarks{get;set;}
        public DateTime TimeStamp{get;set;}

        public Member Member{get;set;}
    }
}