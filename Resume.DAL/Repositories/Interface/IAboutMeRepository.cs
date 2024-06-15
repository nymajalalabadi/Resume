using Resume.DAL.Models.AboutMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IAboutMeRepository
    {
        #region Methods

        Task<AboutMe?> GetAboutMe();

        Task CreateAboutMe(AboutMe aboutMe);

        void UpdateAboutMe(AboutMe aboutMe);

        Task SaveChanges();

        #endregion
    }
}
