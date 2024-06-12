using Resume.Bussines.Services.Interface;
using Resume.DAL.Models.ContactUs;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class ContactUsService : IContactUsService
    {
        #region Constructor

        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        #endregion

        #region Methods

        public async Task<CreateContactUsResult> CreateContactUs(CreateContactUsViewModel model)
        {
            if (model == null)
            {
                return CreateContactUsResult.Error;
            }

            var contactUs = new ContactUs()
            {
                Answer = null,
                Description = model.Description,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Title = model.Title,
            };

            await _contactUsRepository.AddContactUs(contactUs);
            await _contactUsRepository.SaveChanges();

            return CreateContactUsResult.Success;
        }

        public Task<FilterContactUsViewModel> FilterContactUs(FilterContactUsViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ContactUsDetailsViewModel> GetContactUsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnswerResult> AnswerContactUs(ContactUsDetailsViewModel model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
