using Resume.Bussines.Generators;
using Resume.Bussines.Services.Interface;
using Resume.Bussines.Tools;
using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.CustomerFeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
	public class CustomerFeedBackService : ICustomerFeedBackService
	{
		#region Constructor

		private readonly ICustomerFeedBackRepository _customerFeedBackRepository;

		public CustomerFeedBackService(ICustomerFeedBackRepository customerFeedBackRepository)
		{
			_customerFeedBackRepository = customerFeedBackRepository;
		}


		#endregion

		#region Methods

		public async Task<FilterCustomerFeedBackViewModel> FilterCustomerFeedBack(FilterCustomerFeedBackViewModel filter)
		{
			var query = await _customerFeedBackRepository.GetAllCustomerFeedBacks();

			#region Filter

			if (!string.IsNullOrEmpty(filter.Name))
			{
				query = query.Where(c => c.Name.Contains(filter.Name));
			}

			#endregion

			query = query.OrderByDescending(c => c.CreateDate);

			var customerFeedBack = query.Select(c => new CustomerFeedBackViewModel()
			{
				Id = c.Id,
				Avatar = c.Avatar,
				Description = c.Description,
				Name = c.Name
			});

			#region Paging

			await filter.Paging(customerFeedBack);

			#endregion

			return filter;
		}

		public async Task<CreateCustomerFeedBackResult> CreateCustomerFeedBack(CreateCustomerFeedBackViewModel create)
		{
			if (string.IsNullOrEmpty(create.Name)  || string.IsNullOrEmpty(create.Description))
			{
				return CreateCustomerFeedBackResult.Error;
			}

			if (create.Avatar != null)
			{
				var imageNameAvatar = Guid.NewGuid().ToString("N") + Path.GetExtension(create.Avatar!.FileName);

				create.Avatar.AddImageToServer(imageNameAvatar, SiteTools.CustomerFeedBackAvatar);

				var customerFeedBackAvatar = new CustomerFeedBack()
				{
					Description = create.Description,
					Name = create.Name,
					Avatar = imageNameAvatar,
				};

				await _customerFeedBackRepository.AddCustomerFeedBack(customerFeedBackAvatar);
				await _customerFeedBackRepository.SaveChanges();

				return CreateCustomerFeedBackResult.Success;
			}

			var customerFeedBack = new CustomerFeedBack()
			{
				Description = create.Description,
				Name = create.Name,
			};

			await _customerFeedBackRepository.AddCustomerFeedBack(customerFeedBack);
			await _customerFeedBackRepository.SaveChanges();

			return CreateCustomerFeedBackResult.Success;
		}

		public async Task<EditCustomerFeedBackResult> EditCustomerFeedBack(EditCustomerFeedBackViewModel edit)
		{
			var customerFeedBack = await _customerFeedBackRepository.GetCustomerFeedBackById(edit.Id);

			if (customerFeedBack == null)
			{
				return EditCustomerFeedBackResult.CustomerFeedBackNotFound;
			}

			if (edit.Avatar != null)
			{
				var imageNameAvatar = Guid.NewGuid().ToString("N") + Path.GetExtension(edit.Avatar!.FileName);

				edit.Avatar.AddImageToServer(imageNameAvatar, SiteTools.CustomerFeedBackAvatar);

				customerFeedBack!.Name = edit.Name!;
				customerFeedBack.Description = edit.Description!;
				customerFeedBack.Avatar = imageNameAvatar;

				_customerFeedBackRepository.UpdateCustomerFeedBack(customerFeedBack);
				await _customerFeedBackRepository.SaveChanges();

				return EditCustomerFeedBackResult.Success;
			}

			customerFeedBack!.Name = edit.Name!;
			customerFeedBack.Description = edit.Description!;

			_customerFeedBackRepository.UpdateCustomerFeedBack(customerFeedBack);
			await _customerFeedBackRepository.SaveChanges();

			return EditCustomerFeedBackResult.Success;
		}

		public async Task<EditCustomerFeedBackViewModel?> GetCustomerFeedBackById(int id)
		{
			var customer = await _customerFeedBackRepository.GetCustomerFeedBackById(id);

			if (customer == null)
			{
				return null;
			}

			var CustomerFeedBack = new EditCustomerFeedBackViewModel()
			{
				Id = customer.Id,
				Description = customer.Description,
				Name = customer.Name,
				ImageName = customer.Avatar
			};

			return CustomerFeedBack;
		}

		#endregion
	}
}
