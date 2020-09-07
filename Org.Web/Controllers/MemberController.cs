using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.Web.Services;
using Org.Entity;

namespace Org.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly ICommitteeService _committeeApi;
        private readonly IMemberService _memberApi;

        public MemberController(ICommitteeService committeeApi, IMemberService memberApi)
        {
            _committeeApi = committeeApi;
            _memberApi = memberApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> CheckMember(string idCardNumber)
            => Json(await _memberApi.GetMember(idCardNumber));

        [HttpGet]
        public async Task<IActionResult> Create(int? bid)
        {
            ViewBag.IsValid = true;

            var model = new Member();
            if (bid.HasValue)
            {
                model.Branch = await _committeeApi.GetBranch(bid.Value);
                model.BranchId = model.Branch == null ? 0 : model.Branch.Id;
            }

            ViewBag.CommitteeId = model.Branch?.CommitteeId;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member model)
        {
            ViewBag.IsValid = false;

            if (model.BranchId > 0)
            {
                model.Branch = await _committeeApi.GetBranch(model.BranchId);
                model.BranchId = model.Branch == null ? 0 : model.Branch.Id;
            }
            var committeeId = model.Branch?.CommitteeId;
            ViewBag.CommitteeId = committeeId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                model.Branch = null;
                await _memberApi.Create(model);
                if (model.BranchId > 0)
                {
                    return RedirectToAction("Branches", "Committee",
                        new { id = committeeId.Value, bid = model.BranchId });
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberApi.GetMember(id);
            if (member.BranchId > 0)
            {
                member.Branch = await _committeeApi.GetBranch(member.BranchId);
            }

            return View(member);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Member model, string flag)
        {
            if (model.BranchId > 0)
            {
                model.Branch = await _committeeApi.GetBranch(model.BranchId);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var committeeId = model.Branch?.CommitteeId;
            try
            {
                flag = flag.ToLower();
                if (flag != "update" && flag != "verify")
                {
                    ModelState.AddModelError("", "传递了未知的修改标识");
                }
                else
                {
                    if (flag == "update")
                    {
                        await _memberApi.UpdateMember(model);
                    }
                    else
                    {
                        await _memberApi.VerifyMember(model);
                    }
                    if (model.BranchId > 0)
                    {
                        return RedirectToAction("Branches", "Committee",
                            new { id = committeeId.Value, bid = model.BranchId });
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }

            return View(model);


        }
    }
}