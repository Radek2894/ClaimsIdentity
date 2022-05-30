using ClaimsIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimsIdentity.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
