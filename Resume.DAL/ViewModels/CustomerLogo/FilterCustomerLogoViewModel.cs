using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.CustomerLogo
{
    public class FilterCustomerLogoViewModel : BasePaging<CustomerLogoViewModel>
    {
        [Display(Name = "لینک")]
        public string? Link { get; set; }
    }
}
