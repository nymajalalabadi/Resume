using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.CustomerFeedBack
{
	public class CustomerFeedBack : BaseEntity<int>
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Name { get; set; }

		[Display(Name = "آواتار")]
		public string Avatar { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Description { get; set; }
	}
}
