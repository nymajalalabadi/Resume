using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.CustomerFeedBack
{
	public class FilterCustomerFeedBackViewModel : BasePaging<CustomerFeedBackViewModel>
	{
		[Display(Name = "نام")]
		public string Name { get; set; }
	}
}
