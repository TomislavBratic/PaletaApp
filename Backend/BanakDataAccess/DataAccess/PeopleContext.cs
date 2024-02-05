using BanakDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanakDataAccess.DataAccess
{
   public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Address> Adresses { get; set; }


    }
}
