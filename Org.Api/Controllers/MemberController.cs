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
    public class MemberController : ControllerBase
    {
        private readonly OrgContext _context;

        public MemberController(OrgContext context)
        {
            _context = context;
        }

        // GET: api/Member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Member/InBranch/5
        [HttpGet("InBranch/{id}")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembersInBranch(int id)
        {
            return await _context.Members.Where(m => m.BranchId == id).ToListAsync();
        }

        // 返回的会员对象包含了他所属的支部。
        // GET: api/Member/GetByIdCardNumber?idCardNumber=310102197310260496
        [HttpGet("GetByIdCardNumber")]
        public async Task<ActionResult<Member>> GetMember(string idCardNumber)
        {
            var member = await _context.Members.Include(m => m.Branch)
                            .Where(m => m.IdCardNumber == idCardNumber)
                            .FirstOrDefaultAsync();
            if(member != null)
            {
                if(member.Branch != null)
                {
                    member.Branch.Members.Clear();
                }
            }
            return member;
        }

        // GET: api/Member/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Member/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Member
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            var log = new MemberStateLog{
                Member = member,        //EF 跟踪
                State = MemberState.Record,
                StateDate = DateTime.Today,
                TimeStamp = DateTime.Now,
                SubCategory = "补录会员信息",
                Description = "",
            };
            _context.MemberStateLogs.Add(log);
            await _context.SaveChangesAsync();
            
            member.StateLogs.Clear();
            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Member/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
