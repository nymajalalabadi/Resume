using Resume.DAL.Context;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class ContactUsRepository : IContactUsRepository
    {
        #region Constructor

        private ResumeContext _context;

        public ContactUsRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion
    }
}
