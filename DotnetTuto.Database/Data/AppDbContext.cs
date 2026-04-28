using DotnetTuto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Database.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
