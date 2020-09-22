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
    public class BranchRanksController : ControllerBase
    {
        private readonly OrgContext _context;

        public BranchRanksController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/BranchRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchRanks>>> GetBranchRanks()
        {
            return await _context.BranchRanks.ToListAsync();
        }

        // GET: api/BranchRanks/Member/5
        //   根据MemberId检索指定会员在支部任职情况
        [HttpGet("Member/{id}")]
        public async Task<ActionResult<IEnumerable<BranchRanks>>> GetRansOfMember(int id)
        {
            var query = _context.BranchRanks
                            .Include(r=>r.Branch)
                        .Where(r=>r.MemberId==id)
                        .OrderBy(r=>r.AppointDate);
            var ranks = await query.ToListAsync();
            foreach(var r in ranks)
            {
                r.Branch.BranchRanks.Clear();
            }
            return ranks;
        }

        // GET: api/BranchRanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchRanks>> GetBranchRanks(int id)
        {
            var branchRanks = await _context.BranchRanks.FindAsync(id);

            if (branchRanks == null)
            {
                return NotFound();
            }

            return branchRanks;
        }

        // PUT: api/BranchRanks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranchRanks(int id, BranchRanks branchRanks)
        {
            if (id != branchRanks.Id)
            {
                return BadRequest();
            }

            _context.Entry(branchRanks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchRanksExists(id))
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

        // POST: api/BranchRanks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BranchRanks>> PostBranchRanks(BranchRanks branchRanks)
        {
            _context.BranchRanks.Add(branchRanks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranchRanks", new { id = branchRanks.Id }, branchRanks);
        }

        // DELETE: api/BranchRanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BranchRanks>> DeleteBranchRanks(int id)
        {
            var branchRanks = await _context.BranchRanks.FindAsync(id);
            if (branchRanks == null)
            {
                return NotFound();
            }

            _context.BranchRanks.Remove(branchRanks);
            await _context.SaveChangesAsync();

            return branchRanks;
        }

        private bool BranchRanksExists(int id)
        {
            return _context.BranchRanks.Any(e => e.Id == id);
        }
    }
}
