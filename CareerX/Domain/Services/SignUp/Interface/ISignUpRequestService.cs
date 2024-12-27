using Domain.Services.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp.Interface
{
    public interface ISignUpRequestService
    {

        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);
        Task JobSeekerSignupInServiceCreation(JobSeekerSignUpRequestDTOs jobSeekerSignUpRequestDTOs);//(4) call this Interface method From Contoller to Service for Job Seeker SignUp--> go to service
        Task<bool> VerifyJobseekerAsync(Guid jobSeekerSignupRequestId);


        //------------------------ Company Admin -----------------------

        Task CompanyAdminSignupInServiceCreation(CompanyAdminSignUpRequestDTOs companyAdminSignUpRequestDTOs);
        Task<bool> VerifyCompanyAdminAsync(Guid jobSeekerSignupRequestId);
        Task CreateCompany(Guid companySignupRequestId, string password);
    }
}
