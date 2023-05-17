using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentalCarsContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=RentalCars; Trusted_Connection=true");
        }

        public DbSet<Auth> yetki { get; set; }
        public DbSet<Car> araba { get; set; }
        public DbSet<Segment> segment { get; set; }
        public DbSet<User> kullanici { get; set; }
    }
}
