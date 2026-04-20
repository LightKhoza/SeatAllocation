using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatAllocation.DTOs;
using SeatAllocation.Services;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        public async Task<IActionResult> CreateParticipant([FromBody] ParticipantDTO dto)
        {
          
        }
    }
}
