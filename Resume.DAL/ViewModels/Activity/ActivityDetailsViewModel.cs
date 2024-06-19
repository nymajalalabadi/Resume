using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Activity
{
    public class ActivityDetailsViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Icon { get; set; }

		public int? ColumnLg { get; set; }

		public DateTime CreateDate { get; set; }
    }
}
