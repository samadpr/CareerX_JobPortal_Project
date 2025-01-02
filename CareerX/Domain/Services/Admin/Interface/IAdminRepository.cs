using Domain.Models;
using Domain.Services.Admin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interface
{
    public interface IAdminRepository
    {
        Task<List<Domain.Models.JobSeeker>> GetJobSeekers();
        Task<List<Domain.Models.CompanyAdmin>> GetCompanies();

        public bool DeleteById(Guid id);



        //public int GetJobProviderCount();
        //public int GetJobCount();

        //public Task<List<JobPost>> GetJobs(string JobLitle);//search


        //public Task<List<CompanyAdmin>> SearchCompanies(string name);

        ///*  public List<JobPost> GetJobs(JobListParams param);*/

        Task<Skill> AddSkillAsync(SkillsDtos skill);

        Task<bool> RemoveSkillAsync(Guid skillId);

        Task<List<Skill>> GetSkills();



        Task<Location> AddLocation(LocationDtos location);

        Task<bool> RemoveLocation(Guid locationId);

        Task<List<Location>> GetAllLocations();

        Task<Qualification> AddQualification(QualificationDtos qualification);

        Task<bool> RemoveQualification(Guid qaulificationId);

        Task<List<Qualification>> GetAllQualifications();

        Task<Industry> AddIndustries(IndustryDtos industry);

        Task<bool> RemoveIndustries(Guid id);

        Task<List<Industry>> GetIndustries();

        Task<JobCategory> AddJobCategory(CategoryDtos jobCategory);

        Task<bool> RemoveJobCategory(Guid jobCategoryId);

        Task<List<JobCategory>> GetJobCategories();



        //Task<List<JobPost>> GetJobs();
    }
}
