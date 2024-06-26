﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Tools
{
    public class SiteTools
    {

        #region DefaultNames

        public static string DefaultImageName { get; set; } = "/site/img/main-photo.svg";

		#endregion

		#region About me

		public static string AboutMeAvatar { get; set; } = "/Img/AboutMe/";

		#endregion

		#region Customer Feed Back

		public static string CustomerFeedBackAvatar { get; set; } = "/Img/CustomerFeedBack/";

        #endregion

        #region Customer Logo 



        public static string CustomerLogoAvatar { get; set; } = "/Img/CustomerLogo/";

        public static string DefaultCustomerLogoAvatar { get; set; } = "/site/img/logo-1.svg";

        #endregion
    }
}
