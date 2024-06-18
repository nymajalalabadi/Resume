using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Activity
{
    public class FilterActivityViewModel : BasePaging<ActivityDetailsViewModel>
    {
        [Display(Name ="عنوان")]
        public string Title { get; set; }
    }
}
