using System.Data.Entity;
using Abp.EntityFramework;
using Abp.Auditing;
using MultipleDbContextDemo.Core;

namespace MultipleDbContextDemo.EntityFramework
{
    public class MySecondDbContext : AbpDbContext
    {
        
        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<AccountInfo> Accounts { get; set; }

        public virtual IDbSet<Dictionary> Dictionary { get; set; }
        public MySecondDbContext()
            : base("Default2")
        {
            
        }

        

    }
}
