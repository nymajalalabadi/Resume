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
    }
}
