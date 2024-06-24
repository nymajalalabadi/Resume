using Resume.DAL.Models.Education;
using Resume.DAL.Models.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IExperienceRepository
    {
        #region Methods

        Task<IQueryable<Experience>> GetAllExperiences();

        Task<Experience?> GetExperienceById(int id);

        Task AddExperience(Experience Experience);

        void UpdateExperience(Experience Experience);

        Task SaveChanges();

        #endregion
    }
}
