using System;
using Microsoft.EntityFrameworkCore;

namespace note6.Controllers.Data
{
    public class DataContext : DbContext
    {
       public DataContext (DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
    }
}

