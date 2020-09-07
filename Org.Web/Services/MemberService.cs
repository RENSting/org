using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Org.Entity;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Org.Web.Services
{
    public class MemberService : IMemberService
    {
        const string ROUTE_MEMBER = "api/Member";
        const string ROUTE_ITEM_LOG = "api/MemberItemLog";

        const string FORMAT_MEMBER_IN_BRANCH = "api/Member/InBranch/{0}"; // api/Member/InBranch/5
        //  api/Member/GetByIdCardNumber?idCardNumber=310102197310260496
        const string FORMAT_MEMBER_CHECK_IDCARD = "api/Member/GetByIdCardNumber?idCardNumber={0}";

        private readonly IApiConnector _api;

        public MemberService(IApiConnector api) => _api = api;

        /// <summary>
        /// 创建新会员，同时添加会员状态日志
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task Create(Member member) =>
            await _api.HttpPostAsync<Member, Member>(ROUTE_MEMBER, member);

        public async Task<Member> GetMember(string idCardNumber)
            => await _api.HttpGetAsync<Member>(
                string.Format(FORMAT_MEMBER_CHECK_IDCARD, idCardNumber)
            );

        public async Task<Member> GetMember(int id)
            => await _api.HttpGetAsync<Member>(ROUTE_MEMBER + $"/{id}");

        public async Task<IEnumerable<Member>> GetMembersInBranch(int branchId)
            => await _api.HttpGetAsync<IEnumerable<Member>>(
                string.Format(FORMAT_MEMBER_IN_BRANCH, branchId)
            );

        public async Task UpdateMember(Member member)
        {
            //先读取原信息，然后保存新信息，成功后，逐项对比，为每个修改生成日志，
            var oldMember = await GetMember(member.Id);
            if (oldMember == null || oldMember.Id != member.Id)
                throw new System.Exception("没有找到要变更信息的会员");

            try
            {
                await _api.HttpPutAsync<Member, StatusCodeResult>(
                    ROUTE_MEMBER + $"/{member.Id}", member);

                #region 逐项对比是否发生了变化，如果变化就记录变更日志

                if (oldMember.BirthDate != member.BirthDate)
                {
                    await InsertMemberItemLog(member.Id, "出生日期", oldMember.BirthDate, member.BirthDate, "");
                }
                if (oldMember.BranchId != member.BranchId)
                {
                    string oldBranch = (await _api.HttpGetAsync<Branch>($"api/Branch/{oldMember.BranchId}"))?.Name;
                    string newBranch = (await _api.HttpGetAsync<Branch>($"api/Branch/{member.BranchId}"))?.Name;
                    await InsertMemberItemLog(member.Id, "所属支部", oldBranch, newBranch, "");
                }
                if (oldMember.CareerDate != member.CareerDate)
                {
                    await InsertMemberItemLog(member.Id, "参加工作时间", oldMember.CareerDate, member.CareerDate, "");
                }
                if (oldMember.Education != member.Education)
                {
                    await InsertMemberItemLog(member.Id, "教育背景", oldMember.Education, member.Education, "");
                }
                if (oldMember.Email != member.Email)
                {
                    await InsertMemberItemLog(member.Id, "电子邮件", oldMember.Email, member.Email, "");
                }
                if (oldMember.Gender != member.Gender)
                {
                    await InsertMemberItemLog(member.Id, "性别", oldMember.Gender, member.Gender, "");
                }
                if (oldMember.IdCardNumber != member.IdCardNumber)
                {
                    await InsertMemberItemLog(member.Id, "身份证号", oldMember.IdCardNumber, member.IdCardNumber, "");
                }
                if (oldMember.IsActive != member.IsActive)
                {
                    await InsertMemberItemLog(member.Id, "是否有效", oldMember.IsActive, member.IsActive, "");
                }
                if (oldMember.IsCandidate != member.IsCandidate)
                {
                    await InsertMemberItemLog(member.Id, "发展中", oldMember.IsCandidate, member.IsCandidate, "");
                }
                if (oldMember.MobilePhone != member.MobilePhone)
                {
                    await InsertMemberItemLog(member.Id, "手机号码", oldMember.MobilePhone, member.MobilePhone, "");
                }
                if (oldMember.Name != member.Name)
                {
                    await InsertMemberItemLog(member.Id, "姓名", oldMember.Name, member.Name, "");
                }
                if (oldMember.Nation != member.Nation)
                {
                    await InsertMemberItemLog(member.Id, "民族", oldMember.Nation, member.Nation, "");
                }
                if (oldMember.NativePlace != member.NativePlace)
                {
                    await InsertMemberItemLog(member.Id, "籍贯", oldMember.NativePlace, member.NativePlace, "");
                }
                if (oldMember.Remarks != member.Remarks)
                {
                    await InsertMemberItemLog(member.Id, "备注信息", oldMember.Remarks, member.Remarks, "");
                }
                if (oldMember.ResideAddress != member.ResideAddress)
                {
                    await InsertMemberItemLog(member.Id, "家庭住址", oldMember.ResideAddress, member.ResideAddress, "");
                }
                if (oldMember.ResideCity != member.ResideCity)
                {
                    await InsertMemberItemLog(member.Id, "居住省市", oldMember.ResideCity, member.ResideCity, "");
                }
                if (oldMember.ResideDistrict != member.ResideDistrict)
                {
                    await InsertMemberItemLog(member.Id, "居住区县", oldMember.ResideDistrict, member.ResideDistrict, "");
                }
                if (oldMember.SocialPosition != member.SocialPosition)
                {
                    await InsertMemberItemLog(member.Id, "社会职务", oldMember.SocialPosition, member.SocialPosition, "");
                }
                if (oldMember.Sponsor1 != member.Sponsor1)
                {
                    await InsertMemberItemLog(member.Id, "入会介绍人1", oldMember.Sponsor1, member.Sponsor1, "");
                }
                if (oldMember.Sponsor2 != member.Sponsor2)
                {
                    await InsertMemberItemLog(member.Id, "入会介绍人2", oldMember.Sponsor2, member.Sponsor2, "");
                }
                if (oldMember.StemTitle != member.StemTitle)
                {
                    await InsertMemberItemLog(member.Id, "职称", oldMember.StemTitle, member.StemTitle, "");
                }
                if (oldMember.WorkAddress != member.WorkAddress)
                {
                    await InsertMemberItemLog(member.Id, "单位地址", oldMember.WorkAddress, member.WorkAddress, "");
                }
                if (oldMember.WorkCity != member.WorkCity)
                {
                    await InsertMemberItemLog(member.Id, "工作省市", oldMember.WorkCity, member.WorkCity, "");
                }
                if (oldMember.WorkDistrict != member.WorkDistrict)
                {
                    await InsertMemberItemLog(member.Id, "工作区县", oldMember.WorkDistrict, member.WorkDistrict, "");
                }
                if (oldMember.WorkPost != member.WorkPost)
                {
                    await InsertMemberItemLog(member.Id, "职务", oldMember.WorkPost, member.WorkPost, "");
                }
                if (oldMember.WorkUnit != member.WorkUnit)
                {
                    await InsertMemberItemLog(member.Id, "工作单位", oldMember.WorkUnit, member.WorkUnit, "");
                }
                
                #endregion
            }
            catch
            {
                throw;
            }
        }

        private async Task InsertMemberItemLog(int memberId, string itemName,
            object oldValue, object newValue, string remarks)
        {
            var itemLog = new MemberItemLog
            {
                ItemName = itemName,
                MemberId = memberId,
                OldValue = Convert.ToString(oldValue),
                NewValue = Convert.ToString(newValue),
                Remarks = remarks,
                TimeStamp = DateTime.Now,
            };
            await _api.HttpPostAsync<MemberItemLog, MemberItemLog>(
                ROUTE_ITEM_LOG, itemLog);
        }

        public async Task VerifyMember(Member member)
            => await _api.HttpPutAsync<Member, StatusCodeResult>(
                ROUTE_MEMBER + $"/{member.Id}", member);
    }
}