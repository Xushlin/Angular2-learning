using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Angular2.Leaning.Data.Mappings;
using Angular2.Leaning.Data.Migrations;

namespace Angular2.Leaning.Data
{
    public class AngularDbContext : DbContext
    {
        public AngularDbContext():base("name=AngularDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AngularDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new EmployeeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
