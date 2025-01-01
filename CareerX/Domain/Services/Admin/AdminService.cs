using AutoMapper;
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
        { 
            _adminRepository = adminRepository; 
        }

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

        public async Task<Skill> AddSkillAsync(SkillsDtos skill)
        {
            return await _adminRepository.AddSkillAsync(skill);
        }

        public async Task<bool> RemoveSkillAsync(Guid skillId)
        {
            return await _adminRepository.RemoveSkillAsync(skillId);
        }
        
        public async Task<List<Skill>> GetSkills()
        {
            return await _adminRepository.GetSkills();
        }

        public async Task<Location> AddLocation(LocationDtos location)
        {
            return await _adminRepository.AddLocation(location);
        }

        public async Task<bool> RemoveLocation(Guid locationId)
        {
            return await _adminRepository.RemoveLocation(locationId);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _adminRepository.GetAllLocations();
        }

        public async Task<Qualification> AddQualification(QualificationDtos qualification)
        {
            return await _adminRepository.AddQualification(qualification);
        }

        public async Task<bool> RemoveQualification(Guid qualificationId)
        {
            return await _adminRepository.RemoveQualification(qualificationId);
        }

        public async Task<List<Qualification>> GetAllQualifications()
        {
            return await _adminRepository.GetAllQualifications();
        }

        public async Task<Industry> AddIndustries(IndustryDtos industry)
        {
            return await _adminRepository.AddIndustries(industry);
        }

        public async Task<bool> RemoveIndustries(Guid id)
        {
            return await _adminRepository.RemoveIndustries(id);
        }

        public async Task<List<Industry>> GetIndustries()
        {
            return await _adminRepository.GetIndustries();
        }
    }
}
