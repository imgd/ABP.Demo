using System.Collections.Generic;

namespace MultipleDbContextDemo.MigrationsSecond
{
    
    using System.Data.Entity.Migrations;
    

    internal sealed class Configuration : DbMigrationsConfiguration<MultipleDbContextDemo.EntityFramework.MySecondDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MigrationsSecond";
        }
        protected override void Seed(MultipleDbContextDemo.EntityFramework.MySecondDbContext context)
        {
            context.Persons.AddOrUpdate(p => p.PersonName,
                new Person("Yunus"),
                new Person("Emre")
                );
        }
    }
}
