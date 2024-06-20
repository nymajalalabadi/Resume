using Resume.DAL.Models.CustomerFeedBack;
using Resume.DAL.Models.CustomerLogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface ICustomerLogoRepository
    {
        #region Methods

        Task<IQueryable<CustomerLogo>> GetAllCustomerLogos();

        Task<CustomerLogo?> GetCustomerLogoById(int id);

        Task AddCustomerLogo(CustomerLogo CustomerLogo);

        void UpdateCustomerLogo(CustomerLogo CustomerLogo);

        Task SaveChanges();

        #endregion
    }
}
