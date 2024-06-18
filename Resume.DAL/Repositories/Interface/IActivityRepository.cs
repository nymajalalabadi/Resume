using Resume.DAL.Models.Activity;
using Resume.DAL.Models.ContactUs;
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

        #endregion
    }
}
