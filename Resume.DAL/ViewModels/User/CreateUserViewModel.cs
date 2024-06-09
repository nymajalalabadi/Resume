using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.User
{
    public class CreateUserViewModel
    {
        #region Properties

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
        public string Mobile { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
        public string LastName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده صحیح نمی باشد.")]
        public string Password { get; set; }

        [Display(Name = "فعال است؟")]
        public bool IsActive { get; set; }

        #endregion
    }

    public enum CreateUserResult
    {
        Success,
        Error
    }
}
