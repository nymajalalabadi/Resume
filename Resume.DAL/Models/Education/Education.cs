using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.Education
{
	public class Education : BaseEntity<int>
	{
		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Title { get; set; }

		[Display(Name = "تاریخ شروع")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public DateOnly StartDate { get; set; }


		[Display(Name = "تاریخ پایان")]
		public DateOnly? EndDate { get; set; }


		[Display(Name = "توضیحات")]
		[MaxLength(1000, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Description { get; set; }
	}
}
