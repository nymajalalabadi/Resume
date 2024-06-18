using Resume.DAL.Models.Activity;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IActivityRepository
    {
        #region Methods

		Task<IQueryable<Activity>> GetAllActivities();

        Task<Activity?> GetActivityById(int id);

        Task<bool> GetActivityByTitle(string title);

        Task CreateActivity(Activity activity);

        void UpdateActivity(Activity activity);

        Task SaveChanges();

        #endregion
    }
}
