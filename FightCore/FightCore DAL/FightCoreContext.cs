using System;
using System.Collections.Generic;
using System.Text;
using FightCore_Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace FightCore_DAL
{
    public class FightCoreContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public FightCoreContext()
        {             
        }

        public FightCoreContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=FightCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
