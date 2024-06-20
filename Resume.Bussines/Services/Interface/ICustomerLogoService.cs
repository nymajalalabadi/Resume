using Resume.DAL.ViewModels.CustomerFeedBack;
using Resume.DAL.ViewModels.CustomerLogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Interface
{
    public interface ICustomerLogoService
    {
        #region Methods

        Task<FillCustomerLogoViewModel> FilterCustomerLogo(FillCustomerLogoViewModel filter);

        Task<CreateCustomerLogoResult> CreateCustomerLogo(CreateCustomerLogoViewModel create);

        Task<EditCustomerLogoViewModel?> GetCustomerLogoById(int id);

        Task<EditCustomerLogoResult> EditCustomerLogo(EditCustomerLogoViewModel edit);

        Task<List<CustomerLogoViewModel>> GetAllCustomerLogos();

        #endregion
    }
}
