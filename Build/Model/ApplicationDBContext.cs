using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Build.Model
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Building_User> Building_User { get; set; }
    }
}
