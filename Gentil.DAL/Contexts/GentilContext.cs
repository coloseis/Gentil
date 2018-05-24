using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gentil.Business.Models;

namespace Gentil.DAL.Contexts
{
    public class GentilContext : DbContext
    {
        public GentilContext() : base("GentilConnectionString")
        {
            Database.SetInitializer<GentilContext>(new CreateDatabaseIfNotExists<GentilContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
