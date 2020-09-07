using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.Entity;

namespace Org.Web.Services
{
    public class CommitteeService : ICommitteeService
    {
        const string ROUTE_COMMITTEE = "api/Committee";
        const string ROUTE_BRANCH = "api/Branch";
        const string FORMAT_BRANCHES_IN_COMMITTEE = "api/Branch/InCommittee/{0}"; //api/Branch/InCommittee/5

        private readonly IApiConnector _api;

        public CommitteeService(IApiConnector api)
        {
            _api = api;
        }

        public async Task<Branch> GetBranch(int id)
            => await _api.HttpGetAsync<Branch>(ROUTE_BRANCH + $"/{id}");

        public async Task<IEnumerable<Branch>> GetBranchesInCommittee(int committeeId)
            => await _api.HttpGetAsync<IEnumerable<Branch>>(
                    string.Format(FORMAT_BRANCHES_IN_COMMITTEE, committeeId));

        public async Task<Committee> GetCommittee(int id)
            => await _api.HttpGetAsync<Committee>(ROUTE_COMMITTEE + $"/{id}");

        public async Task<IEnumerable<Committee>> GetCommittees()
            => await _api.HttpGetAsync<IEnumerable<Committee>>(ROUTE_COMMITTEE);

        public async Task SaveBranch(Branch branch)
        {
            if (branch.Id > 0)
                await _api.HttpPutAsync<Branch, StatusCodeResult>(
                    ROUTE_BRANCH + $"/{branch.Id}", branch);
            else
                await _api.HttpPostAsync<Branch, Branch>(
                    ROUTE_BRANCH, branch);
        }

        public async Task SaveCommittee(Committee committee)
        {
            if (committee.Id > 0)
                await _api.HttpPutAsync<Committee, StatusCodeResult>(
                    ROUTE_COMMITTEE + $"/{committee.Id}", committee);
            else
                await _api.HttpPostAsync<Committee, Committee>(
                    ROUTE_COMMITTEE, committee);
        }
    }
}