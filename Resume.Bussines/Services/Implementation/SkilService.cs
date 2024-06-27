using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Skill;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Skil;

namespace Resume.Bussines.Services.Implementation
{
	public class SkilService : ISkilService
	{
		#region Constructor

		private readonly ISkilRepository _skilRepository;

		public SkilService(ISkilRepository skilRepository)
		{
			_skilRepository = skilRepository;
		}

		#endregion

		#region Methods

		public async Task<FilterSkilViewModel> FilterSkil(FilterSkilViewModel filter)
		{
			var query = await _skilRepository.GetAllSkills();

			#region filter

			if (!string.IsNullOrEmpty(filter.Title))
			{
				query = query.Where(s => s.Title.Contains(filter.Title));
			}

			#endregion

			query = query.OrderByDescending(s => s.CreateDate);

			var skils = query.Select(s => new SkilViewModel()
			{
				Id = s.Id,
				Title = s.Title,
				Percent = s.Percent
			});

			#region paging

			await filter.Paging(skils);

			#endregion

			return filter;
		}

		public async Task<CreateSkilResult> CreateSkil(CreateSkilViewModel create)
		{
			if (string.IsNullOrEmpty(create.Title))
			{
				return CreateSkilResult.Error;
			}

			var skil = new Skill()
			{
				Title = create.Title,
				Percent = create.Percent
			};

			await _skilRepository.AddSkill(skil);
			await _skilRepository.SaveChanges();

			return CreateSkilResult.Success;
		}

		public async Task<EditSkilViewModel?> GetEditSkilById(int id)
		{
			var skil = await _skilRepository.GetSkillById(id);

			if (skil == null)
			{
				return null;
			}

			return new EditSkilViewModel()
			{
				Id = skil.Id,
				Title = skil.Title,
				Percent = skil.Percent
			};
		}

		public async Task<EditSkilResult> EditSkil(EditSkilViewModel edit)
		{
			var skil = await _skilRepository.GetSkillById(edit.Id);

			if (skil == null)
			{
				return EditSkilResult.SkilNotFount;
			}

			skil.Title = edit.Title;
			skil.Percent = edit.Percent;

			_skilRepository.UpdateSkill(skil);
			await _skilRepository.SaveChanges();

			return EditSkilResult.Success;
		}

		public async Task<List<SkilViewModel>> GetAllSkilViewModel()
		{
			var skils = await _skilRepository.GetAllSkills();

			return await skils.OrderByDescending(s => s.CreateDate).Select(s => new SkilViewModel()
			{
				Id=s.Id,
				Title = s.Title,
				Percent = s.Percent,
			}).ToListAsync();
		}

		#endregion
	}
}
