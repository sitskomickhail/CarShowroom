using System.Reflection;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarShowroom.Entities.DatabaseModels.Context.SqlServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarShowroom.Entities.DatabaseModels.Context.SqlServerContext context) { }
    }
}
