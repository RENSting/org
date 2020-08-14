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
    public class MemberItemLogController : ControllerBase
    {
        private readonly OrgContext _context;

        public MemberItemLogController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/MemberItemLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberItemLog>>> GetMemberItemLogs()
        {
            return await _context.MemberItemLogs.ToListAsync();
        }

        // GET: api/MemberItemLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberItemLog>> GetMemberItemLog(int id)
        {
            var memberItemLog = await _context.MemberItemLogs.FindAsync(id);

            if (memberItemLog == null)
            {
                return NotFound();
            }

            return memberItemLog;
        }

        // PUT: api/MemberItemLog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberItemLog(int id, MemberItemLog memberItemLog)
        {
            if (id != memberItemLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberItemLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberItemLogExists(id))
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

        // POST: api/MemberItemLog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MemberItemLog>> PostMemberItemLog(MemberItemLog memberItemLog)
        {
            _context.MemberItemLogs.Add(memberItemLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberItemLog", new { id = memberItemLog.Id }, memberItemLog);
        }

        // DELETE: api/MemberItemLog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberItemLog>> DeleteMemberItemLog(int id)
        {
            var memberItemLog = await _context.MemberItemLogs.FindAsync(id);
            if (memberItemLog == null)
            {
                return NotFound();
            }

            _context.MemberItemLogs.Remove(memberItemLog);
            await _context.SaveChangesAsync();

            return memberItemLog;
        }

        private bool MemberItemLogExists(int id)
        {
            return _context.MemberItemLogs.Any(e => e.Id == id);
        }
    }
}
