using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.ViewModels.CustomerFeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
	public interface ICustomerFeedBackService
	{
		#region Methods

		Task<FilterCustomerFeedBackViewModel> FilterCustomerFeedBack(FilterCustomerFeedBackViewModel filter);

		Task<CreateCustomerFeedBackResult> CreateCustomerFeedBack(CreateCustomerFeedBackViewModel create);

		Task<EditCustomerFeedBackViewModel?> GetCustomerFeedBackById(int id);

		Task<EditCustomerFeedBackResult> EditCustomerFeedBack(EditCustomerFeedBackViewModel edit);

		#endregion
	}
}
