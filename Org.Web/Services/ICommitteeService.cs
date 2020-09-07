using System.Collections.Generic;
using System.Threading.Tasks;
using Org.Entity;

namespace Org.Web.Services
{
    public interface ICommitteeService
    {
        Task<IEnumerable<Committee>> GetCommittees();

        Task<Committee> GetCommittee(int id);

        Task SaveCommittee(Committee committee);
        /// <summary>
        /// 根据主键获取支部基本信息（其中包含了支部所属委员会的基本信息，以及支部班子成员）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Branch> GetBranch(int id);

        /// <summary>
        /// 获取指定委员会中的全部支部
        /// </summary>
        /// <param name="committeeId"></param>
        /// <returns></returns>
        Task<IEnumerable<Branch>> GetBranchesInCommittee(int committeeId);

        Task SaveBranch(Branch branch);
    }
}