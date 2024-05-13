using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sports_Stats_Back_End.Models;

namespace Sports_Stats_Back_End.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}