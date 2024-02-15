// MyContext.cs
using System;
using System.Data.Entity;
using WpfApp12.Entities;

namespace WpfApp12.DataAccsess
{
    public class MyContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public MyContext() : base("CarDBConnection")
        {
            
        }
    }
}
