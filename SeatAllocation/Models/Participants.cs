namespace SeatAllocation.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public DateTime TimeSlot { get; set; }
        public Session Session { get; set; }
        public int SessionID { get; set; }
        public Divison Divison { get; set; }
        public int DivisonID { get; set; }
    }
}
