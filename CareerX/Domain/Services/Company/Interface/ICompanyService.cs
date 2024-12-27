using Domain.Services.Company.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Company.Interface
{
    public interface ICompanyService
    {
        Task UpdateCompanyDetails(Guid companyId, CompanyDto companyDto);
    }
}
