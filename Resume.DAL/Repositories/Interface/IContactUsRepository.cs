using Resume.DAL.Models.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IContactUsRepository
    {
        #region Methods

        Task AddContactUs(ContactUs contactUs);

        Task SaveChanges();

        #endregion
    }
}
