using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
	public class CustomerFeedBackService : ICustomerFeedBackService
	{
		#region Constructor

		private readonly ICustomerFeedBackRepository _customerFeedBackRepository;

		public CustomerFeedBackService(ICustomerFeedBackRepository customerFeedBackRepository)
		{
			_customerFeedBackRepository = customerFeedBackRepository;
		}

		#endregion

		#region Methods



		#endregion
	}
}
