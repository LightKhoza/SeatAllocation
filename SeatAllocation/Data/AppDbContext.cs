using Microsoft.EntityFrameworkCore;
using SeatAllocation.Models;

namespace SeatAllocation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Divison> Divisons { get; set; }
        public DbSet<Department> Departments { get; set; } 
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<SessionType> SessionTypes { get; set; }
        public DbSet<SessionDepartmentAllocation> SessionDepartmentAllocations { get; set; }
        public DbSet<SessionDivisionAllocation> SessionDivisionAllocations { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
