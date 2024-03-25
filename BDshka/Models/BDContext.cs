using Microsoft.EntityFrameworkCore;

namespace BDshka.Models
{
    public class BDContext : DbContext
    {
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ClientsModel> Clients { get; set; }
        public DbSet<SecurityModel> Secur { get; set; }
        public BDContext(DbContextOptions<BDContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public bool Find(string login, string password)
        {
            foreach (var item in Secur) 
            {
                if (item.Log_in == login && item.Pass_word == password) { return true; }
            }
            return false;
        }
    }
}
