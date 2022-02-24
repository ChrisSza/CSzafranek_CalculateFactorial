using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CSzafranek_CalculateFactorial.Models
{
    public class CalculateFactorialDbContext: DbContext
    {

        public DbSet<CalculateFactorial> CalculateFactorials { get; set;}
        public CalculateFactorialDbContext(): base("FactorialConnection_21")
        {
            Database.SetInitializer<CalculateFactorialDbContext>(new DropCreateDatabaseIfModelChanges<CalculateFactorialDbContext>());
        }
    }
}