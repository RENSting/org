using System.Collections.Generic;
using System.Threading.Tasks;
using Org.Entity;

namespace Org.Web.Services
{
    public interface IMemberService
    {
        /// <summary>
        /// 读取指定支部中的全部会员
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<IEnumerable<Member>> GetMembersInBranch(int branchId);

        Task<Member> GetMember(string idCardNumber);

        Task<Member> GetMember(int id);

        Task Create(Member member);

        /// <summary>
        /// 会员信息变更，每个变更的事项会生成一条变更事项日志
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        Task UpdateMember(Member member);

        /// <summary>
        /// 会员信息勘误，直接修改会员信息，不会生成变更事项日志
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        Task VerifyMember(Member member);

        /// <summary>
        /// 获取指定会员在支部中的任职记录，每个BranchRanks对象包含了支部的基础信息Branch
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IEnumerable<BranchRanks>> GetBranchRanksOfMember(int memberId);

        /// <summary>
        /// 获取指定会员在各个基层委员会中的任职记录，每个CommitteeRanks对象包含了基础信息Committee
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IEnumerable<CommitteeRanks>> GetCommitteeRanksOfMember(int memberId);

        /// <summary>
        /// 简单获取指定会员的事项变更记录，按变更时间倒排序
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IEnumerable<MemberItemLog>> GetMemberItemLogs(int memberId);

        /// <summary>
        /// 简单获取指定会员的状态变更记录，按变更时间倒排序
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IEnumerable<MemberStateLog>> GetMemberStateLogs(int memberId);
    }
}