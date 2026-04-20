using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.Models;
using Microsoft.EntityFrameworkCore;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Departments.ToListAsync());
        }
    }
}
