using Resume.DAL.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Skil
{
	public class FilterSkilViewModel : BasePaging<SkilViewModel>
	{
        public string? Title { get; set; }
    }
}
