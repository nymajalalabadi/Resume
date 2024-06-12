using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.ContactUs
{
    public class ContactUs : BaseEntity<int>
    {
        #region Properties

        public string Title { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string? Answer { get; set; }

        #endregion
    }
}
