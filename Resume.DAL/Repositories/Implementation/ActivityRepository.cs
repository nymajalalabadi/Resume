using Resume.DAL.Context;
using Resume.DAL.Models.Activity;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        #region Constructor

        private ResumeContext _context;

        public ActivityRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<Activity>> GetAllActivities()
        {
            return _context.Activities.AsQueryable();
        }

        #endregion
    }
}
