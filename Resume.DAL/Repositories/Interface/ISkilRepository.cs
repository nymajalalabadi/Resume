using Resume.DAL.Models.Skill;

namespace Resume.DAL.Repositories.Interface
{
	public interface ISkilRepository
	{
		#region Methods

		Task<IQueryable<Skill>> GetAllSkills();

		Task<Skill?> GetSkillById(int id);

		Task AddSkill(Skill Skill);

		void UpdateSkill(Skill Skill);

		Task SaveChanges();

		#endregion
	}
}
