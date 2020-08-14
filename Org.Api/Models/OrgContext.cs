using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Org.Entity;

namespace Org.Api.Models
{
    public class OrgContext : DbContext
    {
        public DbSet<Committee> Committees{get;set;}
        public DbSet<CommitteeRanks> CommitteeRanks{get;set;}
        public DbSet<Branch> Branches{get;set;}
        public DbSet<BranchRanks> BranchRanks{get;set;}
        public DbSet<Member> Members{get;set;}
        public DbSet<MemberItemLog> MemberItemLogs{get;set;}
        public DbSet<MemberStateLog> MemberStateLogs{get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=./Data/org.db");
    }
}