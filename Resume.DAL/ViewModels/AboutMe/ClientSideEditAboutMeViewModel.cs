using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.AboutMe
{
    public class ClientSideEditAboutMeViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Display(Name = "نام")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? LastName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        [EmailAddress(ErrorMessage = "لطفا فرمت ایمیل معتبر وارد کنید")]
        public string? Email { get; set; }


        [Display(Name = "موبایل")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Mobile { get; set; }


        [Display(Name = "بیوگرافی")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Bio { get; set; }


        [Display(Name = "سمت")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Position { get; set; }


        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateOnly? BirthDate { get; set; }


        [Display(Name = "آدرس")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Location { get; set; }

        [Display(Name = "اسم تصویر")]
        public string ImageName { get; set; }

        #endregion
    }

}
