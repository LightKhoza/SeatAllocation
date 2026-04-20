using SeatAllocation.Models;

namespace SeatAllocation.DTOs
{
    public class ParticipantDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public int SessionID { get; set; }
        public int DivisonID { get; set; }
    }
}
