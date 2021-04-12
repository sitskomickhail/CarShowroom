using System.Data.Entity;

namespace CarShowroom.Entities.DatabaseModels.Context
{
    public class SqlServerContext : DbContext
    {
        private const string _databaseName = "ShowroomDb";

        public SqlServerContext() : base(_databaseName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOptional(v => v.Sale)
                .WithRequired(s => s.Vehicle);

            modelBuilder.Entity<Vehicle>()
                .HasOptional(v => v.Maintenance)
                .WithRequired(s => s.Vehicle);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Maintenances)
                .WithRequired(c => c.Client);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Sales)
                .WithRequired(c => c.Client);
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Client> Clients { get; set; }
    }
}