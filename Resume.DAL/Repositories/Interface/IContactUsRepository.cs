using Resume.DAL.Models.ContactUs;
using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.User;
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

		Task<IQueryable<ContactUs>> GetAllContactUs();

		Task AddContactUs(ContactUs contactUs);

        Task SaveChanges();

        #endregion
    }
}
