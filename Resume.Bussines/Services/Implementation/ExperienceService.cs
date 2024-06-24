using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        #endregion
    }
}
