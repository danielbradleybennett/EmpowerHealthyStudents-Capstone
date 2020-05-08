using System;
using System.Collections.Generic;
using System.Text;
using EmpowerHealthyStudents.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using EmpowerHealthyStudents.Models.ViewModels;

namespace EmpowerHealthyStudents.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<BlogPost> BlogPost { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            //modelBuilder.Entity<Comment>()
            //    .HasMany(c => c.BlogComment)
            //    .WithOne(l => l.Comment)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.OrderProducts)
            //    .WithOne(l => l.Order)
            //    .OnDelete(DeleteBehavior.Restrict);


            ApplicationUser user = new ApplicationUser
            {
                FirstName = "April",
                LastName = "Crenshaw",
                UserName = "admin@admin.com",
                IsAdmin = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "10000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Making Healthy Choices",
                    Description = "This guided handout allows adolescents to identify the unhealthy coping skills they use when their emotions are overwhelming and to choose from 50 healthy coping skills instead!",
                    UserId = user.Id
                },
                new Product()
                {
                    Id = 2,
                    Name = "Ten Tips To Build Your Resilience",
                    Description = "These ten tips come in a.pdf format and can be printed as a poster in your classroom, given to students, or displayed on a screen!",
                    UserId = user.Id
                },
                new Product()
                {
                    Id = 3,
                    Name = "Hamlet Character Smackdown: Roleplay Lesson",
                    Description = "In this post - reading activity for Shakespeare's Hamlet, the students will roleplay as different characters. They will be pitted against each other and attempt to defend their character's right to exist within the play.After each smackdown match - up, the class will vote on who does a better job of defending themselves.The winner will move on to the next round. The process will be completed until there is only one student left standing.Feel free to crate a championship belt for the winner of this activity!",
                    UserId = user.Id
                });
            modelBuilder.Entity<Event>().HasData(
                new Event()
                {
                    Id = 1,
                    Location = "SEL Teacher Conference: Phoenix, Arizona",
                    Date = DateTime.Parse("06/20/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 2,
                    Location = "Professinal Development Seminar: Atlanta, Georgia",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 3,
                    Location = "High School Leadership Conference: Orlando, FLorida",
                    Date = DateTime.Parse("07/11/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 4,
                    Location = "Literacy and SEL Seminar: Nashville, Tennessee",
                    Date = DateTime.Parse("07/24/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 5,
                    Location = "Teacher Creator Conference: Cleveland, Orlando",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 6,
                    Location = "Secondary SEL Seminar: Seatle, Washington",
                    Date = DateTime.Parse("08/12/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 7,
                    Location = "National Educator Conference: Chicago, Illinois",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                });

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost()
                {
                    Id = 1,
                    Title = "Teaching in Quarantine",
                    Blog = "Teaching In Quarantine: How Do I Stay Motivated? Distance learning has now been in effect for several weeks, and I know many teachers who are struggling to maintain motivation.Let’s face it - it’s springtime, the weather is getting nicer, and it’s those last few weeks before school is over.If you’re anything like me, it’s hard to get motivated right now! Here are ten tips that I use daily to stay motivated during quarantine: 1.Maintain a daily schedule.Go to bed and get up at the same time each day and take scheduled breaks and lunch. 2.Keep a To - Do List.Marking off items on a list helps me to keep going until the list is clear! 3.Connect with friends and family each day 4.Exercise for at least 30 minutes 5.Journal 6.Get enough sleep 7.Drinks LOTS of water 8.Avoid social media during “work” hours 9.Connect with other teachers 10.Give yourself some grace!",
                    Date = DateTime.Parse("04/21/20"),
                    UserId = user.Id
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    Text = "You are a Godsend.",
                    Date = DateTime.Parse("05/21/20"),
                    UserId = user.Id,
                    BlogPostId = 1
                });

           
        }

       
    }
}










