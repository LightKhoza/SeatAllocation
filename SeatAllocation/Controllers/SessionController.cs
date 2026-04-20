using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.Models;
using Microsoft.EntityFrameworkCore;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return Ok(session);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Sessions.ToListAsync());
        }
    }
}
