using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.Models;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionDevisionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionDevisionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SessionDivisionAllocation model)
        {
            model.CurrentCount = 0;

            _context.SessionDivisionAllocations.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
    }
}
