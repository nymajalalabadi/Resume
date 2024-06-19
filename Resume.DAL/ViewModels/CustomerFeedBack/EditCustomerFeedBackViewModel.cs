using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.CustomerFeedBack
{
	public class EditCustomerFeedBackViewModel
	{
		public int Id { get; set; }

		[Display(Name = "آواتار")]
		public IFormFile? Avatar { get; set; }

		[Display(Name = "عکس")]
		public string? ImageName { get; set; }

        [Display(Name = "نام")]
		public string? Name { get; set; }

		[Display(Name = "توضیحات")]
		public string? Description { get; set; }
	}

	public enum EditCustomerFeedBackResult
	{
		Success,
		Error,
		CustomerFeedBackNotFound,
	}
}
