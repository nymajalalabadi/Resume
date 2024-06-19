using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
	public interface ICustomerFeedBackRepository
	{
		#region Methods

		Task<IQueryable<CustomerFeedBack>> GetAllCustomerFeedBacks();

		Task<CustomerFeedBack?> GetCustomerFeedBackById(int id);

		Task AddCustomerFeedBack(CustomerFeedBack customerFeedBack);

		void UpdateCustomerFeedBack(CustomerFeedBack customerFeedBack);

		Task SaveChanges();

		#endregion
	}
}
