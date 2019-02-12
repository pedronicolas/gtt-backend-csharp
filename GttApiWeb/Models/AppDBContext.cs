using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GttApiWeb.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Jira> Jira { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Certificates> Certificates { get; set; }
    }

   
}

