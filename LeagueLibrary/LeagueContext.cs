using LeagueLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueLibrary
{
    public class LeagueContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FUU1BI0\SQLEXPRESS;Initial Catalog=leagueDB;Integrated Security=True");
        }
    }
}
