using Microsoft.EntityFrameworkCore;
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
                    Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B"
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }


        #endregion

    }
}
