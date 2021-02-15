using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentManager.Models
{
    public class ManagementDbContext:DbContext
    {
        public ManagementDbContext(DbContextOptions<ManagementDbContext> options):base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
