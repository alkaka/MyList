using System;
using Microsoft.EntityFrameworkCore;
using MyList.Models;

namespace MyList.Data
{
    public class CustomerlistContext : DbContext
    {
        public CustomerlistContext(DbContextOptions<CustomerlistContext> options) : base(options)
        {

        }

        public DbSet<Customerlist> Customerlist { get; set; }
        public DbSet<Countrylist> Countrylist { get; set; }
    }

}