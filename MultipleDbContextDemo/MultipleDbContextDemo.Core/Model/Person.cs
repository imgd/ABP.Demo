using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace MultipleDbContextDemo.Core
{
    [Table("Person")]
    public class Person : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime AddTime { get; set; }

        public Person()
        {
            AddTime = DateTime.Now;
        }
    }
}
