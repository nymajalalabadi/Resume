using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.Activity;
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
                ColumnLg = activity.ColumnLg,
            });

            #region paging

            await filter.Paging(activity);

            #endregion

            return filter;
        }

        public async Task<EditActivityViewModel?> GetActivityById(int id)
        {
            var edit = await _activityRepository.GetActivityById(id);

            if (edit == null) 
            {
                return null;
            }

            return new EditActivityViewModel()
            {
                Id = edit.Id,
                Title = edit.Title,
                Description= edit.Description,
                Icon = edit.Icon,
                ColumnLg= edit.ColumnLg,
            };
        }

        public async Task<CreateActivityResult> CreateActivity(CreateActivityViewModel create)
        {
            if (await _activityRepository.GetActivityByTitle(create.Title))
            {
                return CreateActivityResult.Error;
            }

            var activity = new Activity()
            {
                Title = create.Title,
                Description = create.Description,
                Icon = create.Icon,
                ColumnLg = create.ColumnLg,
            };

            await _activityRepository.CreateActivity(activity);
            await _activityRepository.SaveChanges();

            return CreateActivityResult.Success;
        }

        public async Task<EditActivityResult> EditActivity(EditActivityViewModel edit)
        {
            var activity = await _activityRepository.GetActivityById(edit.Id);

            if (activity == null)
            {
                return EditActivityResult.ActivityNotFound;
            }

            activity.Title = edit.Title;
            activity.Description = edit.Description;
			activity.ColumnLg = edit.ColumnLg;
            activity.Icon = edit.Icon;
            
            _activityRepository.UpdateActivity(activity);
            await _activityRepository.SaveChanges();

            return EditActivityResult.Success;
        }

		public async Task<List<ActivityDetailsViewModel>> GetAllActivities()
        {
            var activity = await _activityRepository.GetAllActivities();

            return await activity.Select(a => new ActivityDetailsViewModel() 
            { 
                Title = a.Title,
                Description = a.Description,
                Icon = a.Icon,
                ColumnLg = a.ColumnLg,
            }).ToListAsync();
		}

		#endregion
	}
}
