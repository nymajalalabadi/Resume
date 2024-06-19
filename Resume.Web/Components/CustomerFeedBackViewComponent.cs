using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interface;

namespace Resume.Web.Components
{
    public class CustomerFeedBackViewComponent : ViewComponent
    {
        #region Constructor

        private readonly ICustomerFeedBackService _customerFeedBackService;

        public CustomerFeedBackViewComponent(ICustomerFeedBackService customerFeedBackService)
        {
            _customerFeedBackService = customerFeedBackService;
        }

        #endregion

        #region Method

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _customerFeedBackService.GetAllCustomerFeedBacks();

            return View("CustomerFeedBack", model);
        }

        #endregion
    }
}
