using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.AboutMe
{
    public class AboutMe : BaseEntity<int>
    {
        #region Properties

        [Display(Name = "نام")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? LastName { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Email { get; set; }


        [Display(Name = "موبایل")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Mobile { get; set; }


        [Display(Name = "بیوگرافی")]
        [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Bio { get; set; }


        [Display(Name = "سمت")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Position { get; set; }


        [Display(Name = "تاریخ تولد")]
        public DateOnly? BirthDate { get; set; }


        [Display(Name = "آدرس")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده مجاز نمی باشد")]
        public string? Location { get; set; }


        [Display(Name = "اسم تصویر")]
        public string? ImageName { get; set; }

        #endregion
    }

}
