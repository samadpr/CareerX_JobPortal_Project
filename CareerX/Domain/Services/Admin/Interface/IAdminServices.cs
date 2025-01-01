using Domain.Models;
using Domain.Services.Admin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interface
{
    public interface IAdminServices
    {
        Task<List<Domain.Models.JobSeeker>> GetJobSeekers();
        Task<List<Domain.Models.CompanyAdmin>> GetCompanies();

        public bool DeleteById(Guid id);


        //public int GetJobProviderCount();
        //public int GetJobCount();

        //public Task<List<JobPost>> GetJobs(string JobLitle);//search


        //public Task<List<CompanyAdmin>> SearchCompanies(string name);

        ///*  public List<JobPost> GetJobs(JobListParams param);*/

        //Task<bool> AddSkillAsync(SkillsDtos skill);


        //Task<bool> RemoveSkillAsync(Guid skillId);

        //Task<List<Skill>> GetSkills();



        //Task<Location> AddLocation(LocationDtos location);

        //Task<bool> RemoveLocation(Guid locationId);

        //Task<List<Location>> GetLocations();

        //Task<bool> AddQaulification(QualificationDtos qualification);

        //Task<bool> RemoveQaulification(Guid qaulificationId);

        //Task<List<Qualification>> GetQaulifications();

        //Task<List<Industry>> GetIndustries();

        //Task<bool> RemoveIndustries();

        //Task<bool> AddIndustries(IndustriesDtos industry);

        Task<JobCategory> AddJobCategory(CategoryDtos jobCategory);

        //Task<bool> RemoveJobCategory(Guid jobCategoryId);

        //Task<List<JobCategory>> GetJobCategories();



        //Task<List<JobPost>> GetJobs();
    }
}
