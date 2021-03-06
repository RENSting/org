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
    public class CommitteeRanksController : ControllerBase
    {
        private readonly OrgContext _context;

        public CommitteeRanksController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/CommitteeRanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommitteeRanks>>> GetCommitteeRanks()
        {
            return await _context.CommitteeRanks.ToListAsync();
        }

        // GET: api/CommitteeRanks/Member/5
        //   根据MemberId检索指定会员在基层委员会的任职情况
        [HttpGet("Member/{id}")]
        public async Task<ActionResult<IEnumerable<CommitteeRanks>>> GetRansOfMember(int id)
        {
            var query = _context.CommitteeRanks
                            .Include(r=>r.Committee)
                        .Where(r=>r.MemberId==id)
                        .OrderBy(r=>r.AppointDate);
            var ranks = await query.ToListAsync();
            foreach(var r in ranks)
            {
                r.Committee.CommitteeRanks.Clear();
            }
            return ranks;
        }

        // GET: api/CommitteeRanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommitteeRanks>> GetCommitteeRanks(int id)
        {
            var committeeRanks = await _context.CommitteeRanks.FindAsync(id);

            if (committeeRanks == null)
            {
                return NotFound();
            }

            return committeeRanks;
        }

        // PUT: api/CommitteeRanks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommitteeRanks(int id, CommitteeRanks committeeRanks)
        {
            if (id != committeeRanks.Id)
            {
                return BadRequest();
            }

            _context.Entry(committeeRanks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitteeRanksExists(id))
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

        // POST: api/CommitteeRanks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CommitteeRanks>> PostCommitteeRanks(CommitteeRanks committeeRanks)
        {
            _context.CommitteeRanks.Add(committeeRanks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommitteeRanks", new { id = committeeRanks.Id }, committeeRanks);
        }

        // DELETE: api/CommitteeRanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommitteeRanks>> DeleteCommitteeRanks(int id)
        {
            var committeeRanks = await _context.CommitteeRanks.FindAsync(id);
            if (committeeRanks == null)
            {
                return NotFound();
            }

            _context.CommitteeRanks.Remove(committeeRanks);
            await _context.SaveChangesAsync();

            return committeeRanks;
        }

        private bool CommitteeRanksExists(int id)
        {
            return _context.CommitteeRanks.Any(e => e.Id == id);
        }
    }
}
