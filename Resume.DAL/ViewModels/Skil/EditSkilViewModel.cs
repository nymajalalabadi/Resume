using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Skil
{
	public class EditSkilViewModel
	{
		public int Id { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Title { get; set; }


		[Display(Name = "درصد")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MinLength(1, ErrorMessage = "{0} نمیتواند کمتر از {1} کاراکتر باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
		public string Percent { get; set; }
	}

	public enum EditSkilResult
	{
		Success,
		Error,
		SkilNotFount
	}
}
