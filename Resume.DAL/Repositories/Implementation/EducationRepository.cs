using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Education;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
	public class EducationRepository : IEducationRepository
	{
		#region Constructor

		private ResumeContext _context;

		public EducationRepository(ResumeContext context)
		{
			_context = context;
		}

        #endregion

        #region Methods

        public async Task<IQueryable<Education>> GetAllEducations()
        {
            return _context.Educations.AsQueryable();
        }

        public async Task<Education?> GetEducationById(int id)
        {
            return await _context.Educations.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task AddEducation(Education Education)
        {
            await _context.Educations.AddAsync(Education);
        }

        public void UpdateEducation(Education Education)
        {
            _context.Educations.Update(Education);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
