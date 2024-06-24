using Resume.DAL.ViewModels.Experience;

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
