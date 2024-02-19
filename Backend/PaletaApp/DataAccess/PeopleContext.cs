using PaletaApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaletaApp.DataAccess
{
   public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
