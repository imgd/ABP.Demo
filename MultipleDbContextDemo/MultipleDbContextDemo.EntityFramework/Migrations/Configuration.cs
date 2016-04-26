using System.Data.Entity.Migrations;

namespace MultipleDbContextDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MultipleDbContextDemo.EntityFramework.MyFirstDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MultipleDbContextDemo";
        }

        
    }
}
