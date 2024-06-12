using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface IContactUsService
    {
        #region Methods

        Task<CreateContactUsResult> CreateContactUs(CreateContactUsViewModel model);

        Task<FilterContactUsViewModel> FilterContactUs(FilterContactUsViewModel model);

        Task<ContactUsDetailsViewModel> GetContactUsById(int id);

        Task<AnswerResult> AnswerContactUs(ContactUsDetailsViewModel model);

        #endregion
    }
}
