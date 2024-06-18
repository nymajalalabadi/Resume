using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Activity;
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

        public async Task<FilterActivityViewModel> filterActivityViewModel(FilterActivityViewModel filter)
        {
            var query = await _activityRepository.GetAllActivities();

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title)) 
            {
                query = query.Where(a => a.Title.Contains(a.Title));
            }

            #endregion

            query = query.OrderByDescending(a => a.CreateDate);

            var activity = query.Select(activity => new ActivityDetailsViewModel()
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                Icon = activity.Icon,
                CreateDate = activity.CreateDate,
            });

            #region paging

            await filter.Paging(activity);

            #endregion

            return filter;
        }

        #endregion
    }
}
