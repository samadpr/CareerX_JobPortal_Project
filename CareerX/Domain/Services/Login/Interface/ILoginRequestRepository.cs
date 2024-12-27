using Domain.Services.Login.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login.Interface
{
    public interface ILoginRequestRepository
    {
          Domain.Models.AuthUser GetUserByLoginDto(JobSeekerLoginDto jobSeekerLoginDto);

        Models.AuthUser GetCompanyByLoginDto(CompanyLoginDto companyLoginDto);
    }
}
