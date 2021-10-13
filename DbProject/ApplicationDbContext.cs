﻿using DbProject.DatabaseComponents;
using Microsoft.EntityFrameworkCore;

namespace DbProject
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TestDatabse;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<SimpleContent> TableOne { get; set; }
    }
}
