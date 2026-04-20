namespace SeatAllocation.Models
{
    public class SessionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeOnly TimeSlot { get; set; }
        public int Capacity { get; set; }
        public string Notes { get; set; }
        public Session Session { get; set; }
        public int SessionID { get; set; } 
    }
}
