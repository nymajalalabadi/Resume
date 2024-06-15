using Resume.DAL.Models.AboutMe;
using Resume.DAL.ViewModels.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IAboutMeService
    {
        #region Methods

        Task<CreateOrEditAboutMeViewModel> FillCreateOrEditAboutMe();

        Task<bool> CreateOrEditAboutMe(CreateOrEditAboutMeViewModel createOrEditAboutMe);

        #endregion
    }
}
