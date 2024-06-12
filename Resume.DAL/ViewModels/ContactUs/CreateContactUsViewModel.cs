using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.ContactUs
{
    public class CreateContactUsViewModel
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Title { get; set; }


        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Mobile { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        [EmailAddress(ErrorMessage = "لطفا فرمت ایمیل معتبر وارد کنید")]
        public string Email { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string LastName { get; set; }


        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000, ErrorMessage = "تعداد کاراکتر شده بیش از حد مجاز است")]
        public string Description { get; set; }

        #endregion
    }

    public enum CreateContactUsResult
    {
        Success,
        Error
    }
}
