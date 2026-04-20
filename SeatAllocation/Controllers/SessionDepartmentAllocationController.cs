using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.Models;
using Microsoft.EntityFrameworkCore;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionDepartmentAllocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionDepartmentAllocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SessionDepartmentAllocation model)
        {
            model.CurrentCount = 0; 

            _context.SessionDepartmentAllocations.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.SessionDepartmentAllocations
                .Include(x => x.Session)
                .Include(x => x.Department)
                .ToListAsync());
        }
    }
}
