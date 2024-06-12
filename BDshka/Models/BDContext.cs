using Microsoft.EntityFrameworkCore;

namespace BDshka.Models
{
    public partial class BDContext : DbContext
    {
        public DbSet<RolesModel> Roles { get; set; }
        public DbSet<ClientsModel> Clients { get; set; }
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
        public DbSet<Worker_of_RemontModel> Worker_of_Remont { get; set; }
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public BDContext()
        {

        }
        public bool Find(string login)
        {
            foreach (var item in Clients)
            {
                if (item.Log_in == login) { return true; }
            }
            return false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; TrustServerCertificate=true;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientsModel>(entity =>
            {
                entity.HasKey(e => e.ID_Client).HasName("PK_ID_Client");

                entity.Property(e => e.ID_Client).HasColumnName("ID_Client");
                entity.Property(e => e.FIO).HasColumnName("FIO");
                entity.Property(e => e.Phone_Number).HasColumnName("Phone_Number");
                entity.Property(e => e.Pass_word).HasColumnName("Pass_word");
                entity.Property(e => e.Log_in).HasMaxLength(50)
                .IsUnicode(false); 
                entity.Property(e => e.ID_Role).HasColumnName("ID_Role");


            });
            modelBuilder.Entity<RolesModel>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ID_Role");

                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Title).HasColumnName("Title");

            });
            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
