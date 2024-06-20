using Resume.DAL.ViewModels.CustomerFeedBack;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
	public interface IEducationService
	{
        #region Methods

        Task<FilterEducationViewModel> FilterEducation(FilterEducationViewModel filter);

        Task<CreateEducationResult> CreateEducation(CreateEducationViewModel create);

        Task<EditEducationViewModel?> GetEditEducationById(int id);

        Task<EditEducationResult> EditEducation(EditEducationViewModel edit);

        Task<List<EducationViewModel>> GetAllEducationViewModel();

        #endregion
    }
}
