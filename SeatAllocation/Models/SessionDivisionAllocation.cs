namespace SeatAllocation.Models
{
    public class SessionDivisionAllocation
    {
        public int Id { get; set; }

        public int SessionId { get; set; }
        public int DivisionId { get; set; }

        public int MaxAllowed { get; set; }   
        public int CurrentCount { get; set; }

        public Session Session { get; set; }
        public Divison Division { get; set; }
    }
}
