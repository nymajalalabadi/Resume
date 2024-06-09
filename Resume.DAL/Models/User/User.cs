using Resume.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Models.User
{
    public class User : BaseEntity<long>
    {
        #region Properties

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
