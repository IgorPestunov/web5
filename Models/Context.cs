using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Backend5.Models;

namespace Backend5.Models
{
    public class Context : DbContext
    {
        public DbSet<Hospitals> Hospitals { get; set; }
        public DbSet<Labs> Labs { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public Context() { }
    }
}
