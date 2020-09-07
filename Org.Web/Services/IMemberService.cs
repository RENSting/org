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
    }
}