﻿using Domain.Models;
using Domain.Services.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp.Interface
{
    public interface ISignUpRequestRepository
    {
        Guid AddSignupRequestInRepository(SignUpRequest signupRequest);
        void UpdateSignupRequestInRepository(SignUpRequest signupRequest);
        Task<SignUpRequest> GetSignupRequestById(Guid id);
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);


        Task AddCompanyAsync(Models.CompanyAdmin companyAdmin);
    }
}
