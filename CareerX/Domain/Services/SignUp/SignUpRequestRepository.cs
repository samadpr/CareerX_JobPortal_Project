using Domain.Enums;
using Domain.Models;
using Domain.Services.SignUp.DTOs;
using Domain.Services.SignUp.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp
{
    public class SignUpRequestRepository:ISignUpRequestRepository
    {
        protected readonly CareerxDbContext _context;
         
        public SignUpRequestRepository(CareerxDbContext context)
        {
            _context = context;
        }
       public  Guid AddSignupRequestInRepository(SignUpRequest signUpRequest)
        {
            signUpRequest.Status = Enums.Status.PENDING;
            _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;   
        }
        public async Task<SignUpRequest> GetSignupRequestById(Guid id)
        {
            return await _context.SignUpRequests.FindAsync(id);
        }
        public void UpdateSignupRequestInRepository(SignUpRequest signupRequest)
        {
            _context.SignUpRequests.Update(signupRequest);
            _context.SaveChanges();
        }
        public async Task AddJobSeekerAsync(Models.JobSeeker jobseeker)
        {
            _context.JobSeekers.AddAsync(jobseeker);
            await _context.SaveChangesAsync();
            JobSeekerProfile jobSeekerProfile = new JobSeekerProfile();
 jobSeekerProfile.JobSeekerId = jobseeker.Id;
            _context.JobSeekerProfiles.AddAsync(jobSeekerProfile);
            await _context.SaveChangesAsync();
        }


        public async Task AddCompanyAsync(Models.CompanyAdmin company)
        {
            _context.CompanyAdmins.AddAsync(company);
            await _context.SaveChangesAsync();
        }




    }
}
