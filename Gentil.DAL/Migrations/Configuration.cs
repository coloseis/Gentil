using Gentil.Business.Models;

namespace Gentil.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Gentil.DAL.Contexts.GentilContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gentil.DAL.Contexts.GentilContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var role = new Role();
            role.Name = "Administrador";
            context.Roles.AddOrUpdate(role);

            context.Roles.AddOrUpdate(new Role { Name = "Usuario" });

            var user = new User();
            user.Name = "admin";
            user.Password = "admin";
            user.Role = role;
            context.Users.AddOrUpdate(user);

            context.SaveChanges();
        }
    }
}
