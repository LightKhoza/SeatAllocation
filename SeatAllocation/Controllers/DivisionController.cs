using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.Models;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DivisionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Divison division)
        {
            _context.Divisons.Add(division);
            await _context.SaveChangesAsync();
            return Ok(division);
        }
    }
}
