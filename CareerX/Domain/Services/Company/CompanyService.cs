using Domain.Services.Company.DTOs;
using Domain.Services.Company.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Company
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task UpdateCompanyDetails(Guid companyId, CompanyDto companyDto)
        {
            // 1. Retrieve the existing company details using the repository
            Models.CompanyAdmin company = await _companyRepository.GetCompanyByIdAsync(companyId);
            if (company == null)
            {
                throw new ArgumentException("Company not found.");
            }

            // 2. Update the company details (this includes updating the password if necessary)
            company.AdminName = companyDto.AdminName;
            company.LegalName = companyDto.LegalName;
            company.Summary = companyDto.Summary;
            company.IndustryId = companyDto.IndustryId;
            company.Email = companyDto.Email;
            company.Phone = companyDto.Phone;
            company.Address = companyDto.Address;
            company.Website = companyDto.Website;
            company.Location = companyDto.Location;

            // 3. Save the changes to the database
            await _companyRepository.UpdateCompanyAsync(company);
        }
    }
}
