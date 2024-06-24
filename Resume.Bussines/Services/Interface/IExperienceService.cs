using Resume.DAL.ViewModels.Education;
using Resume.DAL.ViewModels.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IExperienceService
    {
        #region Methods

        Task<FilterExperienceViewModel> FilterExperience(FilterExperienceViewModel filter);

        Task<CreateExperienceResult> CreateExperience(CreateExperienceViewModel create);

        Task<EditExperienceViewModel?> GetEditExperienceById(int id);

        Task<EditExperienceResult> EditExperience(EditExperienceViewModel edit);

        Task<List<ExperienceViewModel>> GetAllExperienceViewModel();

        #endregion
    }
}
