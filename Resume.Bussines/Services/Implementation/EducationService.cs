using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
	public class EducationService : IEducationService
	{
		#region Constructor

		private readonly IEducationRepository _educationRepository;

		public EducationService(IEducationRepository educationRepository)
		{
			_educationRepository = educationRepository;
		}

		#endregion

		#region Methods



		#endregion
	}
}
