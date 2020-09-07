using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.Entity;
using Org.Web.Models;
using Org.Web.Services;

namespace Org.Web.Controllers
{
    public class CommitteeController : Controller
    {
        private readonly ICommitteeService _committeeApi;
        private readonly IMemberService _memberApi;

        public CommitteeController(ICommitteeService committeeApi, IMemberService memberApi)
        {
            _committeeApi = committeeApi;
            _memberApi = memberApi;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _committeeApi.GetCommittees();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Committee model;
            if (id == null)
            {
                model = new Committee();
            }
            else
            {
                model = await _committeeApi.GetCommittee(id.Value);
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Committee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _committeeApi.SaveCommittee(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRanks(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Branches(int id, int? bid)
        {
            //使用委员会主键id构建支部清单页视图模型
            var model = new BranchesViewModel();
            model.ThisCommittee = await _committeeApi.GetCommittee(id);
            ((List<Branch>)model.Branches).AddRange(
                await _committeeApi.GetBranchesInCommittee(id)
            );
            if (bid == null || bid.Value <= 0)
            {
                model.SelectedBranch = model.Branches.FirstOrDefault();
            }
            else
            {
                model.SelectedBranch = model.Branches.Where(b => b.Id == bid.Value).FirstOrDefault();
            }
            if (model.SelectedBranch != null)
            {
                //读取该支部中的所有会员
                var members = await _memberApi.GetMembersInBranch(model.SelectedBranch.Id);
                foreach (var m in members)
                {
                    model.Members.Add(m);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Branches(BranchesViewModel model)
        {
            return RedirectToAction(nameof(Branches),
                new
                {
                    id = model.ThisCommittee.Id,
                    bid = model.SelectedBranch.Id
                });
        }

        [HttpGet]
        public async Task<IActionResult> EditBranch(int? cid, int? id)
        {
            Branch model;
            if (id == null)
            {
                if (cid == null)
                    throw new Exception("必须传递cid参数");
                var committee = await _committeeApi.GetCommittee(cid.Value);
                if (committee == null || committee.Id <= 0)
                    throw new Exception("传递了无效的委员会主键");

                //为委员会创建一个新的支部
                model = new Branch
                {
                    CommitteeId = cid.Value,
                    Committee = committee,
                    CurrentSequence = 1,
                    FoundDate = DateTime.Today
                };
            }
            else
            {
                //编辑一个已有的支部信息
                model = await _committeeApi.GetBranch(id.Value);
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBranch(Branch model)
        {
            if (!ModelState.IsValid)
            {
                model.Committee = await _committeeApi.GetCommittee(model.CommitteeId);
                return View(model);
            }

            try
            {
                await _committeeApi.SaveBranch(model);
                return RedirectToAction(nameof(Branches), new { id = model.CommitteeId });
            }
            catch (Exception ex)
            {
                model.Committee = await _committeeApi.GetCommittee(model.CommitteeId);
                ModelState.AddModelError("", ex.ToString());
                return View(model);
            }
        }
    }
}