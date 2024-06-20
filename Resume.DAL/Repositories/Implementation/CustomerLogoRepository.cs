using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.CustomerLogo;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class CustomerLogoRepository : ICustomerLogoRepository
    {
        #region Constructor

        private ResumeContext _context;

        public CustomerLogoRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IQueryable<CustomerLogo>> GetAllCustomerLogos()
        {
            return _context.CustomerLogos.AsQueryable();
        }

        public async Task<CustomerLogo?> GetCustomerLogoById(int id)
        {
            return await _context.CustomerLogos.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task AddCustomerLogo(CustomerLogo CustomerLogo)
        {
            await _context.CustomerLogos.AddAsync(CustomerLogo);
        }

        public  void UpdateCustomerLogo(CustomerLogo CustomerLogo)
        {
            _context.CustomerLogos.Update(CustomerLogo);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
