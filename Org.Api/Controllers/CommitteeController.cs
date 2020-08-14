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
    public class CommitteeController : ControllerBase
    {
        private readonly OrgContext _context;

        public CommitteeController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/Committee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Committee>>> GetCommittees()
        {
            return await _context.Committees.ToListAsync();
        }

        // GET: api/Committee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Committee>> GetCommittee(int id)
        {
            var committee = await _context.Committees.FindAsync(id);

            if (committee == null)
            {
                return NotFound();
            }

            return committee;
        }

        // PUT: api/Committee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommittee(int id, Committee committee)
        {
            if (id != committee.Id)
            {
                return BadRequest();
            }

            _context.Entry(committee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommitteeExists(id))
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

        // POST: api/Committee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Committee>> PostCommittee(Committee committee)
        {
            _context.Committees.Add(committee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommittee", new { id = committee.Id }, committee);
        }

        // DELETE: api/Committee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Committee>> DeleteCommittee(int id)
        {
            var committee = await _context.Committees.FindAsync(id);
            if (committee == null)
            {
                return NotFound();
            }

            _context.Committees.Remove(committee);
            await _context.SaveChangesAsync();

            return committee;
        }

        private bool CommitteeExists(int id)
        {
            return _context.Committees.Any(e => e.Id == id);
        }
    }
}
