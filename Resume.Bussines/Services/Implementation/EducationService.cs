using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Education;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.CustomerFeedBack;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
	public class EducationService : IEducationService
	{
		#region Constructor

		private readonly IEducationRepository _educationRepository;

		public EducationService(IEducationRepository educationRepository)
		{
			_educationRepository = educationRepository;
		}

        #endregion

        #region Methods

        public async Task<FilterEducationViewModel> FilterEducation(FilterEducationViewModel filter)
        {
            var query = await _educationRepository.GetAllEducations();

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

            var education = query.Select(e => new EducationViewModel()
            {
                Title = e.Title,
                Description = e.Description,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Id = e.Id,
                CreateDate = e.CreateDate,
            });

            #region paging

            await filter.Paging(education);

            #endregion

            return filter;
        }

        public async Task<CreateEducationResult> CreateEducation(CreateEducationViewModel create)
        {
            if (string.IsNullOrEmpty(create.Title) || string.IsNullOrEmpty(create.Description))
            {
                return CreateEducationResult.Error;
            }

            var education = new Education()
            {
                Title = create.Title,
                Description = create.Description,
                StartDate = create.StartDate,
                EndDate = create.EndDate,
            };

            await _educationRepository.AddEducation(education);
            await _educationRepository.SaveChanges();

            return CreateEducationResult.Success;   
        }

        public async Task<EditEducationViewModel?> GetEditEducationById(int id)
        {
            var education = await _educationRepository.GetEducationById(id);

            if (education == null)
            {
                return null;
            }

            return new EditEducationViewModel()
            {
                Title = education.Title,
                Description = education.Description,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Id = education.Id
            };
        }

        public async Task<EditEducationResult> EditEducation(EditEducationViewModel edit)
        {
            var education = await _educationRepository.GetEducationById(edit.Id);

            if (education == null)
            {
                return EditEducationResult.EducationNotFound;
            }

            education.Title = edit.Title;
            education.Description = edit.Description;
            education.StartDate = edit.StartDate;
            education.EndDate = edit.EndDate;

            _educationRepository.UpdateEducation(education);
            await _educationRepository.SaveChanges();

            return EditEducationResult.Success;
        }

        public async Task<List<EducationViewModel>> GetAllEducationViewModel()
        {
            var educations = await _educationRepository.GetAllEducations();

            return await educations.Select(educations => new EducationViewModel()
            {
                Id = educations.Id,
                Description = educations.Description,
                Title = educations.Title,
                StartDate = educations.StartDate,
                EndDate = educations.EndDate,
            }).ToListAsync();
        }

        #endregion
    }
}
