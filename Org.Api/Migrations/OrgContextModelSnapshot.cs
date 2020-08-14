﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.Api.Models;

namespace Org.Api.Migrations
{
    [DbContext(typeof(OrgContext))]
    partial class OrgContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Org.Entity.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommitteeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentSequence")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommitteeId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Org.Entity.BranchRanks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AppointDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RemoveDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sequence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("MemberId");

                    b.ToTable("BranchRanks");
                });

            modelBuilder.Entity("Org.Entity.Committee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentSequence")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Committees");
                });

            modelBuilder.Entity("Org.Entity.CommitteeRanks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AppointDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CommitteeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RemoveDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sequence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommitteeId");

                    b.HasIndex("MemberId");

                    b.ToTable("CommitteeRanks");
                });

            modelBuilder.Entity("Org.Entity.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CareerDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Education")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdCardNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCandidate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nation")
                        .HasColumnType("TEXT");

                    b.Property<string>("NativePlace")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResideAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResideCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("ResideDistrict")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialPosition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sponsor1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sponsor2")
                        .HasColumnType("TEXT");

                    b.Property<string>("StemTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkDistrict")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkPost")
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkUnit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Org.Entity.MemberItemLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NewValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("OldValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberItemLogs");
                });

            modelBuilder.Entity("Org.Entity.MemberStateLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubCategory")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberStateLogs");
                });

            modelBuilder.Entity("Org.Entity.Branch", b =>
                {
                    b.HasOne("Org.Entity.Committee", "Committee")
                        .WithMany("Branches")
                        .HasForeignKey("CommitteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Org.Entity.BranchRanks", b =>
                {
                    b.HasOne("Org.Entity.Branch", "Branch")
                        .WithMany("BranchRanks")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Org.Entity.Member", "Member")
                        .WithMany("BranchRanks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Org.Entity.CommitteeRanks", b =>
                {
                    b.HasOne("Org.Entity.Committee", "Committee")
                        .WithMany("CommitteeRanks")
                        .HasForeignKey("CommitteeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Org.Entity.Member", "Member")
                        .WithMany("CommitteeRanks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Org.Entity.Member", b =>
                {
                    b.HasOne("Org.Entity.Branch", null)
                        .WithMany("Members")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Org.Entity.MemberItemLog", b =>
                {
                    b.HasOne("Org.Entity.Member", "Member")
                        .WithMany("ItemLogs")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Org.Entity.MemberStateLog", b =>
                {
                    b.HasOne("Org.Entity.Member", "Member")
                        .WithMany("StateLogs")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}