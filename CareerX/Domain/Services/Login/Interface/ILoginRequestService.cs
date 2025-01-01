using Domain.Services.Login.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login.Interface
{
    public interface ILoginRequestService
    {
        JobSeekerLoginDto login (JobSeekerLoginDto dto);

        CompanyLoginDto CompanyLogin (CompanyLoginDto dto);
        Models.AuthUser AdminLogin(AdminLoginDtos admin);

    }
}
