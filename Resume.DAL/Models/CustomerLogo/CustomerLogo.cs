using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.CustomerLogo
{
    public class CustomerLogo : BaseEntity<int>
    {
        [Display(Name = "لوگو")]
        public string? Logo { get; set; }

        [Display(Name = "توضیحات لوگو")]
        public string? LogoAlt { get; set; }

        [Display(Name = "لینک")]
        public string? Link { get; set; }
    }
}
