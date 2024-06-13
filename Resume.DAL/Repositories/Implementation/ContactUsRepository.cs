using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        #region Constructor

        private ResumeContext _context;

        public ContactUsRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<ContactUs?> GetContactUsById(int id)
        {
            return await _context.ContactUs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IQueryable<ContactUs>> GetAllContactUs()
        {
            return _context.ContactUs.AsQueryable();
        }

		public async Task AddContactUs(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
        }

        public void Update(ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }


        #endregion
    }
}
