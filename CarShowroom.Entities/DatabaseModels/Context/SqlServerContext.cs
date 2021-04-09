using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Entities.DatabaseModels.Context
{
    public class SqlServerContext : DbContext
    {
        private const string _databaseName = "ShowroomDb";

        public SqlServerContext() : base(_databaseName) { }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}