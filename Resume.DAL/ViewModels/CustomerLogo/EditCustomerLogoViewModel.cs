using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.CustomerLogo
{
    public class EditCustomerLogoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "لوگو")]
        public string? Logo { get; set; }

        [Display(Name = "آواتار")]
        public IFormFile? Avatar { get; set; }

        [Display(Name = "توضیحات لوگو")]
        public string? LogoAlt { get; set; }

        [Display(Name = "لینک")]
        public string? Link { get; set; }
    }
}
