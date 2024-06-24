using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Experience;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ExperienceRepository : IExperienceRepository
    {
        #region Constructor

        private ResumeContext _context;

        public ExperienceRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<Experience>> GetAllExperiences()
        {
            return _context.Experiences.AsQueryable();
        }

        public async Task<Experience?> GetExperienceById(int id)
        {
            return await _context.Experiences.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddExperience(Experience Experience)
        {
            await _context.Experiences.AddAsync(Experience);
        }

        public void UpdateExperience(Experience Experience)
        {
            _context.Experiences.Update(Experience);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
