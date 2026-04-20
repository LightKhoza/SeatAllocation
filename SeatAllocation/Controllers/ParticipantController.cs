using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatAllocation.Data;
using SeatAllocation.DTOs;
using SeatAllocation.Models;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateParticipant([FromBody] ParticipantDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var participant = new Participants
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    DepartmentID = dto.DepartmentID,
                    SessionID = dto.SessionID,
                    DivisonID = dto.DivisonID
                };

                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();

                return CreatedAtAction(
                    nameof(GetParticipantById),
                    new { id = participant.Id },
                    participant
                );
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new
                {
                    message = "Error saving data",
                    detail = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var participant = await _context.Participants
                .Include(p => p.Department)
                .Include(p => p.Session)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (participant == null)
                return NotFound();

            return Ok(participant);
        }
    }
}