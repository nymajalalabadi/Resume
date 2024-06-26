﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Activity
{
    public class EditActivityViewModel
    {
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(750, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Description { get; set; }

        [Display(Name = "ایکون")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string? Icon { get; set; }

		[Display(Name = "عرض ستون آیتم")]
		[Range(4, 12, ErrorMessage = "مقدار وارد شده باید بین 4 تا 12 باشد.")]
		public int ColumnLg { get; set; }
	}

    public enum EditActivityResult
    {
        Success,
        Error,
        ActivityNotFound
    }
}
