using Microsoft.EntityFrameworkCore;

namespace BDshka.Models
{
    public class BDContext : DbContext
    {
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ClientsModel> Clients { get; set; }
        public DbSet<SecurityModel> Secur { get; set; }
        public DbSet<Book_of_MaterialModel> Book_of_Material { get; set; }
        public DbSet<Category_of_MaterialModel> Category_of_Material { get; set; }
        public DbSet<Category_of_Remonts> Category_of_Remonts { get; set; }
        public DbSet<Material_NaborModel> Material_Nabor { get; set; }
        public DbSet<Order_MaterialModel> Order_Material { get; set; }
        public DbSet<Order_RemontModel> Order_Remont { get; set; }
        public DbSet<RemontsModel> Remonts { get; set; }
        public DbSet<Spec_of_WorkersModel> Spec_of_Workers { get; set; }
        public DbSet<SpecModel> Spec { get; set; }
        public DbSet<StatModel> Stat { get; set; }  
        public DbSet<WorkersModel> Workers { get; set; }
        public Dbset<Worker_of_RemontModel> Worker_of_Remont { get; set; }
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
