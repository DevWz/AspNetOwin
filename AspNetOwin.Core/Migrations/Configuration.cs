namespace AspNetOwin.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetOwin.Core.Models.DB.AspNetOwinDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNetOwin.Core.Models.DB.AspNetOwinDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Clientes.AddOrUpdate(new Models.Cliente[]
            {
                new Models.Cliente()
                {
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                }
            });
        }
    }
}
