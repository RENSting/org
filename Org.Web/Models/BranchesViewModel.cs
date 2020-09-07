using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.Entity;

namespace Org.Web.Models
{
    public class BranchesViewModel
    {
        /// <summary>
        /// 视图中的支部所属的委员会
        /// </summary>
        /// <value></value>
        public Committee ThisCommittee { get; set; }
        /// <summary>
        /// 此委员会包含的所有支部
        /// </summary>
        /// <typeparam name="Branch"></typeparam>
        /// <returns></returns>
        public ICollection<Branch> Branches { get; } = new List<Branch>();
        /// <summary>
        /// 当前选择的支部，包含了支部班子成员
        /// </summary>
        /// <value></value>
        public Branch SelectedBranch { get; set; }
        /// <summary>
        /// 选择的支部中的所有会员
        /// </summary>
        /// <typeparam name="MemberItemViewModel"></typeparam>
        /// <returns></returns>
        public ICollection<MemberItemViewModel> Members { get; } = new List<MemberItemViewModel>();

        /// <summary>
        /// 只读，使用当前委员会包含的支部构造dropdown选项列表
        /// </summary>
        /// <returns></returns>
        public SelectList BranchesList =>
            new SelectList(Branches, nameof(Branch.Id), nameof(Branch.ShortName));
    }
}