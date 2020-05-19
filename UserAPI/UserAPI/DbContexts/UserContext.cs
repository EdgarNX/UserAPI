using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Entity;

namespace UserAPI.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = Guid.Parse("6b1eea43-5597-45a6-bdea-e68c60564247"),
                Name = "Edgar",
                Password = "123456"

            },
            new User
            {
                Id = Guid.Parse("a052a63d-fa53-44d5-a197-83089818a676"),
                Name = "Ianko",
                Password = "123456"
            },
            new User
            {
                Id = Guid.Parse("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"),
                Name = "Fernando",
                Password = "123456"
            },
            new User
            {
                Id = Guid.Parse("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"),
                Name = "Paul",
                Password = "123456"
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
