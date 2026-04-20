namespace SeatAllocation.Models
{
    public class Divison
    {
        public int Id { get; set; }
        public DateTime TimeSlot { get; set; }
        public int TotalParticipants { get; set; }
        public int SeatsAllocated { get; set; }
        public int MaxPerSession { get; set; }
        public int TotalSeats { get; set; }
    }
}
