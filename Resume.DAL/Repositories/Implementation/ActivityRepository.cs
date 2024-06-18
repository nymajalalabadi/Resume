using Microsoft.EntityFrameworkCore;
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

        public async Task<Activity?> GetActivityById(int id)
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> GetActivityByTitle(string title)
        {
            return await _context.Activities.Where(a => a.Title.Equals(title)).AnyAsync();
        }

        public async Task CreateActivity(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
