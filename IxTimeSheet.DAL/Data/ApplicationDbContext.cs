using IxTimeSheet.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;

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

        public object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
