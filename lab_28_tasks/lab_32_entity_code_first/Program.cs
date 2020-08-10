using lab_32_entity_code_first.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_32_entity_code_first
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Category> categories = new List<Category>();

            using (var db = new UserDBContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                // add an Item
                // Note autoincrement is on
                //var user = new User()
                //{
                //    Username = "Super Extra User"
                //};
                //db.Users.Add(user);
                //db.SaveChanges();

                users = db.Users.Include("Category").ToList();
                categories = db.Categories.ToList();
                users.ForEach(user => Console.WriteLine($"User {user.UserId} {user.Username} has date of birth {user.DateOfBirth} With Category {user.Category.CategoryName}"));
                categories.ForEach(category => Console.WriteLine($"Cat Id {category.CategoryId, -20} Name {category.CategoryName}"));
            }
        }
    }
}

