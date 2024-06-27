using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Skill;
using Resume.DAL.Repositories.Interface;

namespace Resume.DAL.Repositories.Implementation
{
	public class SkilRepository : ISkilRepository
	{
		#region Constructor

		private ResumeContext _context;

		public SkilRepository(ResumeContext context)
		{
			_context = context;
		}

		#endregion

		#region Methods

		public async Task<IQueryable<Skill>> GetAllSkills()
		{
			return _context.Skills.AsQueryable();
		}

		public async Task<Skill?> GetSkillById(int id)
		{
			return await _context.Skills.FirstOrDefaultAsync(s => s.Id.Equals(id));
		}

		public async Task AddSkill(Skill Skill)
		{
			await _context.Skills.AddAsync(Skill);
		}

		public void UpdateSkill(Skill Skill)
		{
			 _context.Skills.Update(Skill);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		#endregion
	}
}
