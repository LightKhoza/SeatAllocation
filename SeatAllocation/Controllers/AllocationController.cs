using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using Microsoft.EntityFrameworkCore;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AllocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("run")]
        public async Task<IActionResult> RunAllocation()
        {
            var participants = await _context.Participants
                .Where(p => p.SessionID == null)
                .ToListAsync();

            var sessions = await _context.Sessions.ToListAsync();

            var rules = await _context.SessionDepartmentAllocations.ToListAsync();

            foreach (var session in sessions)
            {
                int sessionCount = 0;

                foreach (var deptGroup in participants.GroupBy(p => p.DepartmentID))
                {
                    var rule = rules.First(r =>
                        r.SessionId == session.Id &&
                        r.DepartmentId == deptGroup.Key);

                    int available = rule.MaxAllowed - rule.CurrentCount;

                    var selected = deptGroup
                        .Where(p => p.SessionID == null)
                        .Take(available)
                        .ToList();

                    foreach (var p in selected)
                    {
                        p.SessionID = session.Id;
                        rule.CurrentCount++;
                        sessionCount++;

                        if (sessionCount >= 20)
                            break;
                    }

                    if (sessionCount >= 20)
                        break;
                }
            }

            await _context.SaveChangesAsync();

            return Ok("Allocation completed");
        }
    }
}
