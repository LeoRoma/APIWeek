using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_32_entity_code_first.Models
{
    class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        // no Startup.cs so => connect to database Here!
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlite("DataSource=UserDatabase.db");
            //builder.UseSqlServer(@"DataSource=(localdb)\mssqllocaldb;Initial Catalog = UserDatabase.db;");
        }

        // For seeding we need to add ID, is not going to autoincrement
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User { UserId = 1, Username = "Some User", DateOfBirth=new DateTime(2020,08,09), CategoryId = 1});
            builder.Entity<User>().HasData(new User { UserId = 2, Username = "Another User", DateOfBirth = new DateTime(2020, 08, 08), CategoryId = 2 });
            builder.Entity<User>().HasData(new User { UserId = 3, Username = "Extra User", DateOfBirth = new DateTime(2020, 08, 07), CategoryId = 3 });

            builder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Super User" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Extra User" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Mega User" });

        }
    }
}
