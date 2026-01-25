using LodgeActivityTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LodgeActivityTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
