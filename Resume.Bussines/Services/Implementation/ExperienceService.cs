using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Experience;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;

namespace Resume.Bussines.Services.Implementation
{
    public class ExperienceService : IExperienceService
    {
        #region Constructor

        private readonly IExperienceRepository _experienceRepository;

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        #endregion

        #region Methods

        public async Task<FilterExperienceViewModel> FilterExperience(FilterExperienceViewModel filter)
        {
            var query = await _experienceRepository.GetAllExperiences();

            #region filter

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(e => e.Title.Contains(filter.Title));
            }

            if (filter.StartDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                query = query.Where(e => e.EndDate <= filter.EndDate.Value);
            }

            #endregion

            query = query.OrderByDescending(e => e.CreateDate);

            var experience = query.Select(e => new ExperienceViewModel()
            {
                Id = e.Id,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Description = e.Description,
                CreateDate = e.CreateDate,
            });

            #region paging

            await filter.Paging(experience);

            #endregion

            return filter;
        }

        public async Task<CreateExperienceResult> CreateExperience(CreateExperienceViewModel create)
        {
            if (string.IsNullOrEmpty(create.Title) || string.IsNullOrEmpty(create.Description))
            {
                return CreateExperienceResult.Error;
            }

            var experience = new Experience()
            {
                Title = create.Title,
                Description = create.Description,
                StartDate = create.StartDate,
                EndDate = create.EndDate,
            };

            await _experienceRepository.AddExperience(experience);
            await _experienceRepository.SaveChanges();

            return CreateExperienceResult.Success;
        }

        public async Task<EditExperienceViewModel?> GetEditExperienceById(int id)
        {
            var experince = await _experienceRepository.GetExperienceById(id);

            if (experince == null)
            {
                return null;
            }

            return new EditExperienceViewModel()
            {
                Id = experince.Id,
                Title = experince.Title,
                Description = experince.Description,
                StartDate = experince.StartDate,
                EndDate = experince.EndDate,
            };
        }

        public async Task<EditExperienceResult> EditExperience(EditExperienceViewModel edit)
        {
            var experience = await _experienceRepository.GetExperienceById(edit.Id);

            if (experience == null)
            {
                return EditExperienceResult.ExperienceNotFound;
            }

            experience.Title = edit.Title;
            experience.Description = edit.Description;
            experience.StartDate = edit.StartDate;
            experience.EndDate = edit.EndDate;

            _experienceRepository.UpdateExperience(experience);
            await _experienceRepository.SaveChanges();

            return EditExperienceResult.Success;
        }

        public async Task<List<ExperienceViewModel>> GetAllExperienceViewModel()
        {
            var experince = await _experienceRepository.GetAllExperiences();

            return await experince.OrderByDescending(e => e.CreateDate).Select(e => new ExperienceViewModel()
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                StartDate = e.StartDate,
            }).ToListAsync();
        }

        #endregion
    }
}
