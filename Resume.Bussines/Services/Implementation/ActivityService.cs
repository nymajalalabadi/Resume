using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class ActivityService : IActivityService
    {
        #region Constructor

        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        #endregion

        #region Methods

        #endregion
    }
}
