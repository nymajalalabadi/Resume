using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.AboutMe;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class AboutMeRepository : IAboutMeRepository
    {
        #region Constructor

        private ResumeContext _context;

        public AboutMeRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<AboutMe?> GetAboutMe()
        {
            return await _context.aboutMes.SingleOrDefaultAsync();
        }

        public async Task CreateAboutMe(AboutMe aboutMe)
        {
            await _context.aboutMes.AddAsync(aboutMe);
        }

        public  void UpdateAboutMe(AboutMe aboutMe)
        {
            _context.aboutMes.Update(aboutMe);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
