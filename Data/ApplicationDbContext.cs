using System;
using System.Collections.Generic;
using System.Text;
using EmpowerHealthyStudents.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpowerHealthyStudents.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogComment> BlogComments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    base.OnModelCreating(modelbuilder);


        //    ApplicationUser user = new ApplicationUser
        //    {
        //        FirstName = "April",
        //        LastName = "Crenshaw",
        //        UserName = "admin@admin.com",
        //        IsAdmin = true,
        //        NormalizedUserName = "ADMIN@ADMIN.COM",
        //        Email = "admin@admin.com",
        //        NormalizedEmail = "ADMIN@ADMIN.COM",
        //        EmailConfirmed = true,
        //        LockoutEnabled = false,
        //        SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
        //        Id = "00000000-ffff-ffff-ffff-ffffffffffff"
        //    };
        //    var passwordHash = new PasswordHasher<ApplicationUser>();
        //    user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
        //    modelBuilder.Entity<ApplicationUser>().HasData(user);

        //    ApplicationUser user2 = new ApplicationUser
        //    {
        //        FirstName = "Amon",
        //        LastName = "Arnoth",
        //        UserName = "amon@arnoth.com",
        //        IsAdmin = false,
        //        NormalizedUserName = "AMON@ARNOTH.COM",
        //        Email = "amon@arnoth.com",
        //        NormalizedEmail = "AMON@ARNOTH.COM",
        //        EmailConfirmed = true,
        //        LockoutEnabled = false,
        //        SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
        //        Id = "00000000-ffff-ffff-ffff-ffffffffffff"
        //    };
        //    var passwordHash = new PasswordHasher<ApplicationUser>();
        //    user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
        //    modelBuilder.Entity<ApplicationUser>().HasData(user);

        //}
    }
}
