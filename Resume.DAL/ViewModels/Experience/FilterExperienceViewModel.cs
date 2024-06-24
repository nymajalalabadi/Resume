using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Experience
{
    public class FilterExperienceViewModel : BasePaging<ExperienceViewModel>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }

        [Display(Name = "تاریخ شروع")]
        public DateOnly? StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        public DateOnly? EndDate { get; set; }
    }
}
