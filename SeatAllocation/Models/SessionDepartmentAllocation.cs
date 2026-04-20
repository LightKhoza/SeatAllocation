namespace SeatAllocation.Models
{
    public class SessionDepartmentAllocation
    {
        public int Id { get; set; }

        public int SessionId { get; set; }
        public int DepartmentId { get; set; }

        public int MaxAllowed { get; set; } 
        public int CurrentCount { get; set; } 

        public Session Session { get; set; }
        public Department Department { get; set; }
    }
}
