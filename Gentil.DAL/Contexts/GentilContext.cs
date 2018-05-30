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
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
