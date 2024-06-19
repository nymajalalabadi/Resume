using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
	public class CustomerFeedBackRepository : ICustomerFeedBackRepository
	{
		#region Constructor

		private ResumeContext _context;

		public CustomerFeedBackRepository(ResumeContext context)
		{
			_context = context;
		}

		#endregion

		#region Methods

		public async Task<IQueryable<CustomerFeedBack>> GetAllCustomerFeedBacks()
		{
			return _context.CustomerFeedBacks.AsQueryable();
		}

		public async Task AddCustomerFeedBack(CustomerFeedBack customerFeedBack)
		{
			await _context.CustomerFeedBacks.AddAsync(customerFeedBack);
		}

		public async Task<CustomerFeedBack?> GetCustomerFeedBackById(int id)
		{
			return await _context.CustomerFeedBacks.FirstOrDefaultAsync(c => c.Id.Equals(id));
		}

		public void UpdateCustomerFeedBack(CustomerFeedBack customerFeedBack)
		{
		   _context.CustomerFeedBacks.Update(customerFeedBack);
		}

		public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		#endregion
	}
}
