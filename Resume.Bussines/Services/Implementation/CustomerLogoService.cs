using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Generators;
using Resume.Bussines.Services.Interface;
using Resume.Bussines.Tools;
using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Models.CustomerLogo;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.CustomerFeedBack;
using Resume.DAL.ViewModels.CustomerLogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class CustomerLogoService : ICustomerLogoService
    {
        #region Constructor

        private readonly ICustomerLogoRepository _customerLogoRepository;

        public CustomerLogoService(ICustomerLogoRepository customerLogoRepository)
        {
            _customerLogoRepository = customerLogoRepository;
        }

        #endregion

        #region Methods

        public async Task<FilterCustomerLogoViewModel> FilterCustomerLogo(FilterCustomerLogoViewModel filter)
        {
            var query = await _customerLogoRepository.GetAllCustomerLogos();

            #region filter

            if (!string.IsNullOrEmpty(filter.Link))
            {
                query = query.Where(c => c.Link!.Contains(filter.Link));
            }

            #endregion

            query = query.OrderByDescending(c => c.CreateDate);

            var customerLogo = query.Select(c => new CustomerLogoViewModel()
            {
                Id = c.Id,
                Logo = c.Logo,
                Link = c.Link,
                LogoAlt = c.LogoAlt,
            });

            #region paging

            await filter.Paging(customerLogo);

            #endregion

            return filter;
        }

        public async Task<CreateCustomerLogoResult> CreateCustomerLogo(CreateCustomerLogoViewModel create)
        {
            if (create.Avatar != null)
            {
                var imageNameAvatar = Guid.NewGuid().ToString("N") + Path.GetExtension(create.Avatar!.FileName);

                create.Avatar.AddImageToServer(imageNameAvatar, SiteTools.CustomerLogoAvatar);

                var customerLogoAvatar = new CustomerLogo()
                {
                    Link = create.Link,
                    Logo = imageNameAvatar,
                    LogoAlt= create.LogoAlt,
                };

                await _customerLogoRepository.AddCustomerLogo(customerLogoAvatar);
                await _customerLogoRepository.SaveChanges();

                return CreateCustomerLogoResult.Success;
            }

            var customerLogo = new CustomerLogo()
            {
                Link = create.Link,
                LogoAlt = create.LogoAlt,
            };

            await _customerLogoRepository.AddCustomerLogo(customerLogo);
            await _customerLogoRepository.SaveChanges();

            return CreateCustomerLogoResult.Success;
        }

        public async Task<EditCustomerLogoViewModel?> GetCustomerLogoById(int id)
        {
            var customerLogo = await _customerLogoRepository.GetCustomerLogoById(id);

            if (customerLogo == null)
            {
                return null;
            }

            return new EditCustomerLogoViewModel()
            {
                Id = customerLogo.Id,
                Logo = customerLogo.Logo,
                LogoAlt = customerLogo.LogoAlt,
                Link = customerLogo.Link,
            };
        }

        public async Task<EditCustomerLogoResult> EditCustomerLogo(EditCustomerLogoViewModel edit)
        {
            var customerLogo = await _customerLogoRepository.GetCustomerLogoById(edit.Id);

            if (customerLogo == null)
            {
                return EditCustomerLogoResult.CustomerLogoNotFound;
            }

            if (edit.Avatar != null)
            {
                var imageNameAvatar = Guid.NewGuid().ToString("N") + Path.GetExtension(edit.Avatar!.FileName);

                edit.Avatar.AddImageToServer(imageNameAvatar, SiteTools.CustomerLogoAvatar);

                customerLogo!.LogoAlt = edit.LogoAlt!;
                customerLogo.Link = edit.Link!;
                customerLogo.Logo = imageNameAvatar;

                _customerLogoRepository.UpdateCustomerLogo(customerLogo);
                await _customerLogoRepository.SaveChanges();

                return EditCustomerLogoResult.Success;
            }

            customerLogo!.LogoAlt = edit.LogoAlt!;
            customerLogo.Link = edit.Link!;

            _customerLogoRepository.UpdateCustomerLogo(customerLogo);
            await _customerLogoRepository.SaveChanges();

            return EditCustomerLogoResult.Success;
        }

        public async Task<List<CustomerLogoViewModel>> GetAllCustomerLogos()
        {
            var customerLogo = await _customerLogoRepository.GetAllCustomerLogos();

            return await customerLogo.Select(c => new CustomerLogoViewModel()
            {
                Id = c.Id,
                Logo = c.Logo,
                LogoAlt = c.LogoAlt,
                Link = c.Link,
            }).ToListAsync();
        }

        #endregion
    }
}
