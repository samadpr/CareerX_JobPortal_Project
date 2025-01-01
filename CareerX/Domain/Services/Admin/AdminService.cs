using Domain.Models;
using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin
{
    public class AdminService:IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        { _adminRepository = adminRepository; }

       public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _adminRepository.GetJobSeekers();
        }
        public async Task<List<Domain.Models.CompanyAdmin>> GetCompanies()
        {
            return await _adminRepository.GetCompanies();
        }
        public bool DeleteById(Guid id)
        {
            return _adminRepository.DeleteById(id);
        }
        public async Task<JobCategory> AddJobCategory(CategoryDtos jobCategory)
        {
            return await _adminRepository.AddJobCategory(jobCategory);
        }
    }
}
