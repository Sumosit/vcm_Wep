using Microsoft.EntityFrameworkCore;

namespace dom3.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}