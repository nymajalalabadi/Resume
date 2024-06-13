using Microsoft.EntityFrameworkCore;
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

        public async Task<FilterContactUsViewModel> FilterContactUs(FilterContactUsViewModel model)
        {
            var query = await _contactUsRepository.GetAllContactUs();

			#region filter

			if (!string.IsNullOrEmpty(model.FirstName))
			{
				query = query.Where(contactUs => EF.Functions.Like(contactUs.FirstName, $"%{model.FirstName}%"));
			}

			if (!string.IsNullOrEmpty(model.LastName))
			{
				query = query.Where(contactUs => EF.Functions.Like(contactUs.LastName, $"%{model.LastName}%"));
			}

			if (!string.IsNullOrEmpty(model.Email))
			{
				query = query.Where(contactUs => EF.Functions.Like(contactUs.Email, $"%{model.Email}%"));
			}

			if (!string.IsNullOrEmpty(model.Mobile))
			{
				query = query.Where(contactUs => EF.Functions.Like(contactUs.Mobile, $"%{model.Mobile}%"));
			}

			if (!string.IsNullOrEmpty(model.Title))
			{
				query = query.Where(contactUs => EF.Functions.Like(contactUs.Title, $"%{model.Title}%"));
			}

            #endregion

            #region swich

            switch (model.AnswerStatus)
            {
				case FilterContactUsAnswerStatus.All:
					break;

				case FilterContactUsAnswerStatus.Answered:
					query = query.Where(contactUs => contactUs.Answer != null);
					break;

				case FilterContactUsAnswerStatus.NotAnswered:
					query = query.Where(contactUs => contactUs.Answer == null);
					break;
			}

            #endregion

            query = query.OrderByDescending(contactUs => contactUs.CreateDate);

            var contactUs = query.Select(contactUs => new ContactUsDetailsViewModel()
            {
				Answer = contactUs.Answer,
				ContactUsId = contactUs.Id,
				Description = contactUs.Description,
				Email = contactUs.Email,
				FirstName = contactUs.FirstName,
				LastName = contactUs.LastName,
				Mobile = contactUs.Mobile,
				Title = contactUs.Title,
				CreateDate = contactUs.CreateDate
			});

			#region Pagination

            await model.Paging(contactUs);

            #endregion

            return model;
		}

		public async Task<ContactUsDetailsViewModel> GetContactUsById(int id)
        {
            var contactUs =  await _contactUsRepository.GetContactUsById(id);

            return new ContactUsDetailsViewModel()
            {
                ContactUsId = contactUs!.Id,
                Description = contactUs.Description,
                Email = contactUs.Email,
                FirstName = contactUs.FirstName,
                LastName = contactUs.LastName,
                Mobile = contactUs.Mobile,
                Title = contactUs.Title,
                CreateDate = contactUs.CreateDate,
                Answer = contactUs.Answer,
            };
        }

        public async Task<AnswerResult> AnswerContactUs(ContactUsDetailsViewModel model)
        {
            var contactUs = await _contactUsRepository.GetContactUsById(model.ContactUsId);

            if (contactUs == null)
            {
                return AnswerResult.ContactUsNotFound;
            }
            
            if (string.IsNullOrEmpty(model.Answer))
            {
                return AnswerResult.AnswerIsNull;
            }

            contactUs.Answer = model.Answer;

            _contactUsRepository.Update(contactUs);
            await _contactUsRepository.SaveChanges();

            //string body = await _viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
            //await _emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما", body);

            return AnswerResult.Success;
        }

        #endregion
    }
}
