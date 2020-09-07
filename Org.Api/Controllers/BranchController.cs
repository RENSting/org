using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.Api.Models;
using Org.Entity;

namespace Org.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly OrgContext _context;

        public BranchController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/Branch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }

        // GET: api/Branch/InCommittee/5    id is Committee's primary key
        [HttpGet("InCommittee/{id}")]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranchesInCommittee(int id)
        {
            return await _context.Branches.Where(b => b.CommitteeId == id).ToListAsync();
        }

        // GET: api/Branch/5

        /// <summary>
        /// 返回的结果同时包含了所属的委员会对象，和，支部班子成员，但不包含会员列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id)
        {
            var query = _context.Branches
                            .Include(b => b.Committee)
                            .Include(b => b.BranchRanks)
                                .ThenInclude(r => r.Member);
            var branch = await query.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (branch != null)
            {
                //防止循环引用
                foreach (var r in branch.BranchRanks)
                {
                    r.Branch = null;
                    r.Member.CommitteeRanks.Clear();
                    r.Member.BranchRanks.Clear();
                    r.Member.Branch = null;
                }
                branch.Committee.Branches.Clear();
            }
            return branch;
        }

        // PUT: api/Branch/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, Branch branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Branch
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = branch.Id }, branch);
        }

        // DELETE: api/Branch/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
