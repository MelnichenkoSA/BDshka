using Microsoft.EntityFrameworkCore;

namespace BDshka.Models
{
    public class BDContext : DbContext
    {
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ClientsModel> Clients { get; set; }
        public BDContext(DbContextOptions<BDContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
