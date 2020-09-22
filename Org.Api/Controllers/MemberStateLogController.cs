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
    public class MemberStateLogController : ControllerBase
    {
        private readonly OrgContext _context;

        public MemberStateLogController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/MemberStateLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberStateLog>>> GetMemberStateLogs()
        {
            return await _context.MemberStateLogs.ToListAsync();
        }

        // GET: api/MemberStateLog/Logs/5
        [HttpGet("Logs/{id}")]
        public async Task<ActionResult<IEnumerable<MemberStateLog>>> GetLogsOfMember(int id)
        {
            return await _context.MemberStateLogs
                            .Where(l=>l.MemberId == id)
                            .OrderByDescending(l=>l.TimeStamp)
                            .ToListAsync();
        }

        // GET: api/MemberStateLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberStateLog>> GetMemberStateLog(int id)
        {
            var memberStateLog = await _context.MemberStateLogs.FindAsync(id);

            if (memberStateLog == null)
            {
                return NotFound();
            }

            return memberStateLog;
        }

        // PUT: api/MemberStateLog/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberStateLog(int id, MemberStateLog memberStateLog)
        {
            if (id != memberStateLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberStateLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberStateLogExists(id))
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

        // POST: api/MemberStateLog
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MemberStateLog>> PostMemberStateLog(MemberStateLog memberStateLog)
        {
            _context.MemberStateLogs.Add(memberStateLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberStateLog", new { id = memberStateLog.Id }, memberStateLog);
        }

        // DELETE: api/MemberStateLog/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MemberStateLog>> DeleteMemberStateLog(int id)
        {
            var memberStateLog = await _context.MemberStateLogs.FindAsync(id);
            if (memberStateLog == null)
            {
                return NotFound();
            }

            _context.MemberStateLogs.Remove(memberStateLog);
            await _context.SaveChangesAsync();

            return memberStateLog;
        }

        private bool MemberStateLogExists(int id)
        {
            return _context.MemberStateLogs.Any(e => e.Id == id);
        }
    }
}
