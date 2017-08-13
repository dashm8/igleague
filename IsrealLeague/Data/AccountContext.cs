using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IsrealLeague.Models;

namespace IsrealLeague.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }
        public DbSet<Account> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Account>().ToTable("users");
        }


    }
}
