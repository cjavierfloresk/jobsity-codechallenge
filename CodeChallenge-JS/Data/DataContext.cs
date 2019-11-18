
using CodeChallenge_JS.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeChallenge_JS.Data
{
	public class DataContext : DbContext
    {
        public static string EfCacheDirPath = "";

		public DataContext()
		  : base("DefaultConnection")
		{
			Database.SetInitializer<DataContext>(null);
		}

		public DbSet<Message> Messages { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
		}
    }

	internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}
	}
}
