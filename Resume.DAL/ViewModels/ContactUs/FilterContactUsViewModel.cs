using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.ContactUs
{
    public class FilterContactUsViewModel : BasePaging<ContactUsDetailsViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "ایمیل")]
        public string? Email { get; set; }

        [Display(Name = "موبایل")]
        public string? Mobile { get; set; }

        [Display(Name = "نام")]
        public string? FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }

        [Display(Name = "وضعیت پاسخ")]
        public FilterContactUsAnswerStatus AnswerStatus { get; set; }
    }

    public enum FilterContactUsAnswerStatus
    {
        [Display(Name = "همه")]
        All,

        [Display(Name = "پاسخ داده شده")]
        Answered,

        [Display(Name = "پاسخ داده نشده")]
        NotAnswered
    }

}
