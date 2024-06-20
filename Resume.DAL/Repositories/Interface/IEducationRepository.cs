using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Models.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
	public interface IEducationRepository
	{
        #region methods

        Task<IQueryable<Education>> GetAllEducations();

        Task<Education?> GetEducationById(int id);

        Task AddEducation(Education Education);

        void UpdateEducation(Education Education);

        Task SaveChanges();

        #endregion
    }
}
