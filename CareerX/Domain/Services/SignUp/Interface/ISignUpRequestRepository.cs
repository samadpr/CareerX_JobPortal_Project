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
        void JobSeekerSignupInRepository(JobSeekerSignUpRequestDTOs jobSeekerSignUpRequestDTOs);
    }
}
