using IxTimeSheet.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace IxTimeSheet.DAL.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }    
    }
}
