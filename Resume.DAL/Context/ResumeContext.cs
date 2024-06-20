using Microsoft.EntityFrameworkCore;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Models.Activity;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Models.CustomerLogo;
using Resume.DAL.Models.Education;
using Resume.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Context
{
    public class ResumeContext : DbContext
    {
        #region Constructor

        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {

        }

        #endregion

        #region DbSets

        public DbSet<User> Users { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<AboutMe> aboutMes { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<CustomerFeedBack> CustomerFeedBacks { get; set; }

        public DbSet<CustomerLogo> CustomerLogos { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed data

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    CreateDate = DateTime.Now,
                    Email = "nyma@gmail.com",
                    FirstName = "نیما",
                    LastName = "جلال ابادی",
                    Id = 1,
                    IsActive = true,
                    Mobile = "09367806232",
                    Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B" //12345
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }


        #endregion

    }
}
