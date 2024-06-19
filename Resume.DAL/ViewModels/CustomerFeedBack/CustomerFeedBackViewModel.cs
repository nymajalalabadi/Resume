using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.CustomerFeedBack
{
	public class CustomerFeedBackViewModel
	{
		public long Id { get; set; }

		[Display(Name = "آواتار")]
		public string Avatar { get; set; }

		[Display(Name = "نام")]
		public string Name { get; set; }

		[Display(Name = "توضیحات")]
		public string Description { get; set; }
	}
}
